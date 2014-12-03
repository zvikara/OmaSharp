using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;

namespace WBXML
{
    public class WBXMLDocument : XmlDocument
    {
        private readonly GlobalTokens globalTokens = new GlobalTokens();
        private readonly List<OpaqueDataExpression> opaqueDataExpressions = new List<OpaqueDataExpression>();

        private AttributeCodeSpace attributeCodeSpace = new AttributeCodeSpace();
        private int currentAttributeCodePage;
        private int currentTagCodePage;
        private int publicIdentifier;
        private StringTable stringTable = new StringTable();
        private TagCodeSpace tagCodeSpace = new EmptyCodeSpace();
        private Encoding textEncoding = Encoding.UTF8;
        private double versionNumber;

        public double VersionNumber
        {
            get { return versionNumber; }
            set { versionNumber = value; }
        }

        public int PublicIdentifier
        {
            get { return publicIdentifier; }
            set { publicIdentifier = value; }
        }

        public Encoding Encoding
        {
            get { return textEncoding; }
            set { textEncoding = value; }
        }

        public TagCodeSpace TagCodeSpace
        {
            get { return tagCodeSpace; }
            set { tagCodeSpace = value; }
        }

        public AttributeCodeSpace AttributeCodeSpace
        {
            get { return attributeCodeSpace; }
            set { attributeCodeSpace = value; }
        }

        public StringTable StringTable
        {
            get { return stringTable; }
            set { stringTable = value; }
        }

        public List<OpaqueDataExpression> OpaqueDataExpressions
        {
            get { return opaqueDataExpressions; }
        }

        public void LoadBytes(byte[] bytes)
        {
            DecodeWBXML(bytes);
        }

        #region Decoder

        private void DecodeWBXML(byte[] bytes)
        {
            currentTagCodePage = 0;
            currentAttributeCodePage = 0;

            bool isAttribute = false;
            bool tagHasAttributes = false;
            bool tagHasContent = false;

            XmlNode activeNode = this;
            XmlAttribute activeAttribute = null;

            var byteQueue = new Queue<byte>(bytes);

            //Get the WBXML version number;
            versionNumber = (byteQueue.Dequeue()/10.0) + 1.0;

            //Get the value of the public identifier
            publicIdentifier = GetInt(byteQueue);

            if (publicIdentifier == 0)
            {
                //TODO the publicIdentifier is defined as string inside the stringtable
                int publicIdentifierStringTableIndex = GetInt(byteQueue);
            }

            //Get the charset for text encoding
            textEncoding = IANACharacterSets.GetEncoding(GetInt(byteQueue));

            XmlDeclaration declaration = CreateXmlDeclaration("1.0", textEncoding.WebName, null);
            activeNode.AppendChild(declaration);

            //Get the string table (use of the string table is not implemented)
            int stringTableLength = GetInt(byteQueue);
            if (stringTableLength > 0)
            {
                var byteStringTableQueue = new Queue<byte>();
                for (int i = 0; i < stringTableLength; i++)
                {
                    byteStringTableQueue.Enqueue(byteQueue.Dequeue());
                }

                var stringTableList = new List<string>();

                while (byteStringTableQueue.Count > 0)
                {
                    string stringTableItem = GetString(byteStringTableQueue);
                    stringTableList.Add(stringTableItem);
                }

                stringTable = new StringTable(stringTableList.ToArray());
            }

            //WBXML body
            while (byteQueue.Count > 0)
            {
                byte byteItem = byteQueue.Dequeue();
                if (globalTokens.Contains(byteItem))
                {
                    GlobalTokens.Names globalToken = globalTokens.GetToken(byteItem);
                    switch (globalToken)
                    {
                        case GlobalTokens.Names.SWITCH_PAGE:
                            currentTagCodePage = byteQueue.Dequeue();
                            break;
                        case GlobalTokens.Names.END:
                            if (isAttribute)
                            {
                                isAttribute = false;
                                activeAttribute = null;

                                if (!tagHasContent)
                                {
                                    activeNode = activeNode.ParentNode;
                                }
                            }
                            else
                            {
                                activeNode = activeNode.ParentNode;
                            }
                            break;
                        case GlobalTokens.Names.ENTITY:
                            //TODO ENTITY is not implemented yet
                            int entityLength = GetInt(byteQueue);
                            break;
                        case GlobalTokens.Names.STR_I:
                            if (isAttribute)
                            {
                                activeAttribute.InnerText += GetString(byteQueue);
                            }
                            else
                            {
                                activeNode.AppendChild(CreateTextNode(GetString(byteQueue)));
                            }
                            break;
                        case GlobalTokens.Names.LITERAL:
                        case GlobalTokens.Names.LITERAL_A:
                        case GlobalTokens.Names.LITERAL_AC:
                        case GlobalTokens.Names.LITERAL_C:
                            //TODO LITERALs are not implemented yet
                            int literalReference = GetInt(byteQueue);
                            break;
                        case GlobalTokens.Names.EXT_I_0:
                        case GlobalTokens.Names.EXT_I_1:
                        case GlobalTokens.Names.EXT_I_2:
                            //TODO EXT_I_x are not implemented yet
                            string extiString = GetString(byteQueue);
                            break;
                        case GlobalTokens.Names.PI:
                            //TODO PI is not implemented yet
                            var piByteList = new List<byte>();
                            while (byteQueue.Peek() != (byte) GlobalTokens.Names.END)
                            {
                                piByteList.Add(byteQueue.Dequeue());
                            }
                            byteQueue.Dequeue();
                            break;
                        case GlobalTokens.Names.EXT_T_0:
                        case GlobalTokens.Names.EXT_T_1:
                        case GlobalTokens.Names.EXT_T_2:
                            //TODO EXT_T_x are not implemented yet
                            int exttReference = GetInt(byteQueue);
                            break;
                        case GlobalTokens.Names.STR_T:
                            int strtReference = GetInt(byteQueue);
                            if (stringTable.ContainsString(strtReference))
                            {
                                StringTableItem stringTableItem = stringTable.GetString(strtReference);
                                if (isAttribute)
                                {
                                    activeAttribute.InnerText += stringTableItem.Value;
                                }
                                else
                                {
                                    activeNode.AppendChild(CreateTextNode(stringTableItem.Value));
                                }
                            }
                            break;
                        case GlobalTokens.Names.EXT_0:
                        case GlobalTokens.Names.EXT_1:
                        case GlobalTokens.Names.EXT_2:
                            //TODO EXT_x are not implemented yet
                            break;
                        case GlobalTokens.Names.OPAQUE:
                            int opaqueLength = GetInt(byteQueue);
                            byte[] opaqueByteArray = GetByteArray(byteQueue, opaqueLength);
                            var opaqueHexList = new List<string>();
                            foreach (byte opaqueByteItem in opaqueByteArray)
                            {
                                opaqueHexList.Add(opaqueByteItem.ToString("X2"));
                            }
                            activeNode.InnerText = String.Join("", opaqueHexList.ToArray());
                            break;
                    }
                }
                else if (!isAttribute)
                {
                    tagHasAttributes = IsBitSet(byteItem, 7);
                    tagHasContent = IsBitSet(byteItem, 6);

                    byteItem &= 127;
                    byteItem &= 63;

                    string tagValue;
                    if (tagCodeSpace.GetCodePage(currentTagCodePage).ContainsTag(byteItem))
                    {
                        tagValue = tagCodeSpace.GetCodePage(currentTagCodePage).GetTag(byteItem).Name;
                    }
                    else
                    {
                        tagValue = "Tag_" + byteItem.ToString("X2");
                    }

                    XmlElement xmlElement = CreateElement(tagValue);
                    activeNode.AppendChild(xmlElement);
                    if (tagHasContent || tagHasAttributes)
                    {
                        activeNode = xmlElement;

                        if (tagHasAttributes)
                        {
                            isAttribute = true;
                        }
                    }
                }
                else
                {
                    if (byteItem < 128)
                    {
                        if (attributeCodeSpace.GetCodePage(currentAttributeCodePage).ContainsAttributeStart(byteItem))
                        {
                            AttributeStart attributeStart =
                                attributeCodeSpace.GetCodePage(currentAttributeCodePage).GetAttributeStart(byteItem);
                            XmlAttribute xmlAttribute = CreateAttribute(attributeStart.Name);
                            xmlAttribute.InnerText = attributeStart.Prefix;
                            activeNode.Attributes.Append(xmlAttribute);

                            activeAttribute = xmlAttribute;
                        }
                        else
                        {
                            XmlAttribute xmlAttribute = CreateAttribute("attribute_" + byteItem.ToString("X2"));
                            activeNode.Attributes.Append(xmlAttribute);

                            activeAttribute = xmlAttribute;
                        }
                    }
                    else
                    {
                        if (attributeCodeSpace.GetCodePage(currentAttributeCodePage).ContainsAttributeValue(byteItem))
                        {
                            AttributeValue attributeValue =
                                attributeCodeSpace.GetCodePage(currentAttributeCodePage).GetAttributeValue(byteItem);
                            activeAttribute.InnerText += attributeValue.Value;
                        }
                    }
                }
            }
        }

        #endregion

        #region Encoder

        public byte[] GetBytes()
        {
            currentTagCodePage = 0;
            currentAttributeCodePage = 0;

            var bytesList = new List<byte>();

            //Versionnumber
            bytesList.Add((byte) ((int) ((versionNumber*10) - 10)));

            //Public identifier (currently implemented as unknown)
            bytesList.AddRange(GetMultiByte(tagCodeSpace.GetPublicIdentifier()));

            //Encoding
            bytesList.AddRange(GetMultiByte(IANACharacterSets.GetMIBEnum(textEncoding)));

            //String table length
            int stringTableLength = stringTable.Length;
            if (stringTableLength > 0)
            {
                bytesList.AddRange(GetMultiByte(stringTableLength));
                bytesList.AddRange(stringTable.GetStringTableBytes(textEncoding));
            }
            else
            {
                bytesList.Add(0);
            }

            bytesList.AddRange(EncodeNodes(ChildNodes));

            return bytesList.ToArray();
        }

        private byte[] EncodeNodes(XmlNodeList nodes)
        {
            var bytesList = new List<byte>();

            foreach (XmlNode node in nodes)
            {
                bytesList.AddRange(EncodeNode(node));
            }

            return bytesList.ToArray();
        }

        private byte[] EncodeNode(XmlNode node)
        {
            var bytesList = new List<byte>();

            switch (node.NodeType)
            {
                case XmlNodeType.Element:
                    bool hasAttributes = node.Attributes.Count > 0;
                    bool hasContent = node.HasChildNodes;
                    int codePage = tagCodeSpace.ContainsTag(currentTagCodePage, node.Name);
                    if (codePage >= 0)
                    {
                        if (currentTagCodePage != codePage)
                        {
                            bytesList.Add((byte) GlobalTokens.Names.SWITCH_PAGE);
                            bytesList.Add((byte) codePage);
                            currentTagCodePage = codePage;
                        }

                        byte keyValue = tagCodeSpace.GetCodePage(currentTagCodePage).GetTag(node.Name).Token;
                        if (hasAttributes)
                        {
                            keyValue |= 128;
                        }
                        if (hasContent)
                        {
                            keyValue |= 64;
                        }
                        bytesList.Add(keyValue);
                    }
                    else
                    {
                        //TODO: unkown tag
                    }

                    if (hasAttributes)
                    {
                        foreach (XmlAttribute attribute in node.Attributes)
                        {
                            bytesList.AddRange(EncodeNode(attribute));
                        }
                        bytesList.Add((byte) GlobalTokens.Names.END);
                    }

                    if (hasContent)
                    {
                        bytesList.AddRange(EncodeNodes(node.ChildNodes));
                        bytesList.Add((byte) GlobalTokens.Names.END);
                    }
                    break;
                case XmlNodeType.Text:
                    bool isOpaqueData = false;

                    if (opaqueDataExpressions.Count > 0)
                    {
                        foreach (OpaqueDataExpression expression in OpaqueDataExpressions)
                        {
                            if (expression.TagName.Equals(node.ParentNode.Name))
                            {
                                if (node.ParentNode.SelectSingleNode(expression.Expression) != null)
                                {
                                    isOpaqueData = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (isOpaqueData)
                    {
                        byte[] opaqueDataBytes = GetBytes(node.Value);
                        bytesList.Add((byte) GlobalTokens.Names.OPAQUE);
                        bytesList.AddRange(GetMultiByte(opaqueDataBytes.Length));
                        bytesList.AddRange(opaqueDataBytes);
                    }
                    else
                    {
                        string textValue = node.Value;

                        while (textValue.Length > 0)
                        {
                            int stringTableIndex = textValue.Length;

                            if (stringTable.ContainsString(textValue))
                            {
                                StringTableItem stringTableItem = stringTable.GetString(textValue);
                                stringTableIndex = textValue.IndexOf(stringTableItem.Value);

                                if (stringTableIndex == 0)
                                {
                                    bytesList.Add((byte) GlobalTokens.Names.STR_T);
                                    bytesList.AddRange(GetMultiByte(stringTableItem.Index));
                                    textValue = textValue.Substring(stringTableItem.Value.Length);
                                    continue;
                                }
                            }

                            bytesList.Add((byte) GlobalTokens.Names.STR_I);
                            bytesList.AddRange(textEncoding.GetBytes(textValue.Substring(0, stringTableIndex)));
                            bytesList.Add(0);

                            textValue = textValue.Substring(stringTableIndex);
                        }
                    }
                    break;
                case XmlNodeType.EntityReference:
                    bytesList.Add((byte) GlobalTokens.Names.ENTITY);
                    var reference = (XmlEntityReference) node;
                    foreach (int stringItem in reference.InnerText.ToCharArray())
                    {
                        bytesList.AddRange(GetMultiByte(stringItem));
                    }
                    break;
                case XmlNodeType.Attribute:
                    if (attributeCodeSpace.GetCodePage(currentAttributeCodePage).ContainsAttributeStart(node.Name,
                                                                                                        node.Value))
                    {
                        AttributeStart attributeStart =
                            attributeCodeSpace.GetCodePage(currentAttributeCodePage).GetAttributeStart(node.Name,
                                                                                                       node.Value);
                        bytesList.Add(attributeStart.Token);

                        string postAttributeValue = node.Value.Substring(attributeStart.Prefix.Length);
                        while (postAttributeValue.Length > 0)
                        {
                            int attrValueIndex = postAttributeValue.Length;

                            if (
                                attributeCodeSpace.GetCodePage(currentAttributeCodePage).ContainsAttributeValue(
                                    postAttributeValue))
                            {
                                AttributeValue attrValue =
                                    attributeCodeSpace.GetCodePage(currentAttributeCodePage).GetAttributeValue(
                                        postAttributeValue);
                                attrValueIndex = postAttributeValue.IndexOf(attrValue.Value);

                                if (attrValueIndex == 0)
                                {
                                    bytesList.Add(attrValue.Token);
                                    postAttributeValue = postAttributeValue.Substring(attrValue.Value.Length);
                                    continue;
                                }
                            }

                            int stringTableIndex = postAttributeValue.Length;

                            if (stringTable.ContainsString(postAttributeValue))
                            {
                                StringTableItem stringTableItem = stringTable.GetString(postAttributeValue);
                                stringTableIndex = postAttributeValue.IndexOf(stringTableItem.Value);

                                if (stringTableIndex == 0)
                                {
                                    bytesList.Add((byte) GlobalTokens.Names.STR_T);
                                    bytesList.AddRange(GetMultiByte(stringTableItem.Index));

                                    postAttributeValue = postAttributeValue.Substring(stringTableItem.Value.Length);
                                    continue;
                                }
                            }

                            int firstReferenceIndex = Math.Min(attrValueIndex, stringTableIndex);
                            bytesList.Add((byte) GlobalTokens.Names.STR_I);
                            bytesList.AddRange(
                                textEncoding.GetBytes(postAttributeValue.Substring(0, firstReferenceIndex)));
                            bytesList.Add(0);

                            postAttributeValue = postAttributeValue.Substring(firstReferenceIndex);
                        }
                    }
                    break;
            }

            return bytesList.ToArray();
        }

        #endregion

        #region Util Methods

        private string GetString(Queue<byte> byteQueue)
        {
            var byteList = new List<byte>();
            while (byteQueue.Count > 0 && byteQueue.Peek() != 0)
            {
                byteList.Add(byteQueue.Dequeue());
            }

            if (byteQueue.Count > 0)
            {
                byteQueue.Dequeue();
            }

            return textEncoding.GetString(byteList.ToArray());
        }

        private string GetString(Queue<byte> byteQueue, int length)
        {
            var byteList = new List<byte>();
            for (int i = 0; i < length; i++)
            {
                byteList.Add(byteQueue.Dequeue());
            }
            return textEncoding.GetString(byteList.ToArray());
        }

        private byte[] GetMultiByte(int multiByteValue)
        {
            if (multiByteValue == 0)
            {
                return new byte[] {0x00};
            }
            else
            {
                var multiByteList = new List<byte>();

                while (multiByteValue > 0)
                {
                    int byteValue = 0;
                    for (int i = 0; i < 7; i++)
                    {
                        if (IsBitSet(multiByteValue, i))
                        {
                            byteValue += (int) Math.Pow(2, i);
                        }
                    }

                    if (multiByteList.Count > 0)
                    {
                        byteValue += 128;
                    }

                    multiByteList.Insert(0, (byte) byteValue);
                    multiByteValue >>= 7;
                }

                return multiByteList.ToArray();
            }
        }

        private int GetInt(Queue<byte> byteQueue)
        {
            var multiByteList = new List<byte>();
            while (IsBitSet(byteQueue.Peek(), 7))
            {
                byte byteItem = byteQueue.Dequeue();
                byteItem &= 127;
                multiByteList.Add(byteItem);
            }

            //Add the next byte because it is the last part of the multibyte
            //(or even the only part of the multibyte)
            multiByteList.Add(byteQueue.Dequeue());

            int returnValue = 0;
            for (int i = 0; i < multiByteList.Count; i++)
            {
                int byteValue = multiByteList[i];
                double power = 7*(multiByteList.Count - 1 - i);
                returnValue += (int) (byteValue*Math.Pow(2, power));
            }
            return returnValue;
        }

        private byte[] GetByteArray(Queue<byte> messageQueue, int length)
        {
            var byteList = new List<byte>();
            for (int i = 0; i < length; i++)
            {
                byteList.Add(messageQueue.Dequeue());
            }
            return byteList.ToArray();
        }

        private byte[] GetBytes(string messageValue)
        {
            var byteList = new List<byte>();
            if (messageValue == null || messageValue.Length%2 == 1)
            {
                return byteList.ToArray();
            }

            for (int i = 0; i < messageValue.Length/2; i++)
            {
                byteList.Add((byte) Int32.Parse(messageValue.Substring(i*2, 2), NumberStyles.HexNumber));
            }

            return byteList.ToArray();
        }

        private bool IsBitSet(int byteItem, int bitNumber)
        {
            return ((byteItem & (1 << bitNumber)) == Math.Pow(2, bitNumber));
        }

        #endregion
    }
}