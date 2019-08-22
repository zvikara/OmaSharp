using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using System.Xml;

namespace OmaSharp.WBXML
{
    public class WbxmlDocument : XmlDocument
    {
        private readonly GlobalTokens globalTokens = new GlobalTokens();

        private int currentAttributeCodePage;
        private int currentTagCodePage;
        public double VersionNumber { get; set; }
        public int PublicIdentifier { get; set; }
        public Encoding Encoding { get; set; }
        public TagCodeSpace TagCodeSpace { get; set; }
        public AttributeCodeSpace AttributeCodeSpace { get; set; }
        public StringTable StringTable { get; set; }
        public List<OpaqueDataExpression> OpaqueDataExpressions { get; private set; }

        public WbxmlDocument()
        {
            OpaqueDataExpressions = new List<OpaqueDataExpression>();
            StringTable = new StringTable();
            AttributeCodeSpace = new AttributeCodeSpace();
            TagCodeSpace = new EmptyCodeSpace();
            Encoding = Encoding.UTF8;
        }

        public void LoadBytes(byte[] bytes)
            => Decode(bytes);

        #region Decoder

        private void Decode(IEnumerable<byte> bytes)
        {
            currentTagCodePage = 0;
            currentAttributeCodePage = 0;

            var isAttribute = false;
            var tagHasAttributes = false;
            var tagHasContent = false;

            XmlNode activeNode = this;
            XmlAttribute activeAttribute = null;

            var byteQueue = new Queue<byte>(bytes);

            //Get the WBXML version number;
            VersionNumber = (byteQueue.Dequeue() / 10.0) + 1.0;

            //Get the value of the public identifier
            PublicIdentifier = GetInt(byteQueue);

            if (PublicIdentifier == 0)
            {
                //TODO the publicIdentifier is defined as string inside the stringtable
                var publicIdentifierStringTableIndex = GetInt(byteQueue);
            }

            //Get the charset for text encoding
            Encoding = IanaCharacterSets.GetEncoding(GetInt(byteQueue));

            var declaration = CreateXmlDeclaration("1.0", Encoding.WebName, null);
            activeNode.AppendChild(declaration);

            //Get the string table (use of the string table is not implemented)
            var stringTableLength = GetInt(byteQueue);
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

                StringTable = new StringTable(stringTableList.ToArray());
            }

            //WBXML body
            while (byteQueue.Count > 0)
            {
                var byteItem = byteQueue.Dequeue();
                if (globalTokens.Contains(byteItem))
                {
                    var globalToken = globalTokens.GetToken(byteItem);
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
                            var entityValue = GetInt(byteQueue);
                            var encodedEntity = GetEntity(entityValue);
                            if (isAttribute)
                            {
                                activeAttribute.InnerXml += encodedEntity;
                            }
                            else
                            {
                                activeNode.InnerXml += encodedEntity;
                            }
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
                            var literalReference = GetInt(byteQueue);
                            break;
                        case GlobalTokens.Names.EXT_I_0:
                        case GlobalTokens.Names.EXT_I_1:
                        case GlobalTokens.Names.EXT_I_2:
                            //TODO EXT_I_x are not implemented yet
                            var extiString = GetString(byteQueue);
                            break;
                        case GlobalTokens.Names.PI:
                            //TODO PI is not implemented yet
                            var piByteList = new List<byte>();
                            while (byteQueue.Peek() != (byte)GlobalTokens.Names.END)
                            {
                                piByteList.Add(byteQueue.Dequeue());
                            }
                            byteQueue.Dequeue();
                            break;
                        case GlobalTokens.Names.EXT_T_0:
                        case GlobalTokens.Names.EXT_T_1:
                        case GlobalTokens.Names.EXT_T_2:
                            //TODO EXT_T_x are not implemented yet
                            var exttReference = GetInt(byteQueue);
                            break;
                        case GlobalTokens.Names.STR_T:
                            int strtReference = GetInt(byteQueue);
                            if (StringTable.ContainsString(strtReference))
                            {
                                var stringTableItem = StringTable.GetString(strtReference);
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
                            var opaqueLength = GetInt(byteQueue);
                            var opaqueByteArray = GetByteArray(byteQueue, opaqueLength);
                            var opaqueHexList = new List<string>();
                            foreach (byte opaqueByteItem in opaqueByteArray)
                            {
                                opaqueHexList.Add(opaqueByteItem.ToString("X2"));
                            }
                            activeNode.InnerText = string.Join("", opaqueHexList.ToArray());
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
                    if (TagCodeSpace.GetCodePage(currentTagCodePage).ContainsTag(byteItem))
                    {
                        tagValue = TagCodeSpace.GetCodePage(currentTagCodePage).GetTag(byteItem).Name;
                    }
                    else
                    {
                        tagValue = "Tag_" + byteItem.ToString("X2");
                    }

                    var xmlElement = CreateElement(tagValue);
                    activeNode.AppendChild(xmlElement);
                    if (!tagHasContent && !tagHasAttributes) continue;
                    activeNode = xmlElement;
                    if (tagHasAttributes)
                        isAttribute = true;
                }
                else
                {
                    if (byteItem < 128)
                    {
                        if (AttributeCodeSpace.GetCodePage(currentAttributeCodePage).ContainsAttributeStart(byteItem))
                        {
                            var attributeStart =
                                AttributeCodeSpace.GetCodePage(currentAttributeCodePage).GetAttributeStart(byteItem);
                            var xmlAttribute = CreateAttribute(attributeStart.Name);
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
                        if (!AttributeCodeSpace.GetCodePage(currentAttributeCodePage).ContainsAttributeValue(byteItem))
                            continue;
                        var attributeValue =
                            AttributeCodeSpace.GetCodePage(currentAttributeCodePage).GetAttributeValue(byteItem);
                        activeAttribute.InnerText += attributeValue.Value;
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
            bytesList.Add((byte)(10 * VersionNumber - 10));

            //Public identifier (currently implemented as unknown)
            bytesList.AddRange(GetMultiByte(TagCodeSpace.GetPublicIdentifier()));

            //Encoding
            bytesList.AddRange(GetMultiByte(IanaCharacterSets.GetMIBEnum(Encoding)));

            //String table length
            int stringTableLength = StringTable.Length;
            if (stringTableLength > 0)
            {
                bytesList.AddRange(GetMultiByte(stringTableLength));
                bytesList.AddRange(StringTable.GetStringTableBytes(Encoding));
            }
            else
            {
                bytesList.Add(0);
            }

            bytesList.AddRange(EncodeNodes(ChildNodes));

            return bytesList.ToArray();
        }

        private IEnumerable<byte> EncodeNodes(XmlNodeList nodes)
        {
            var bytesList = new List<byte>();

            foreach (XmlNode node in nodes)
            {
                bytesList.AddRange(EncodeNode(node));
            }

            return bytesList.ToArray();
        }

        private IEnumerable<byte> EncodeNode(XmlNode node)
        {
            var bytesList = new List<byte>();

            switch (node.NodeType)
            {
                case XmlNodeType.Element:
                    if (node.Name == "characteristic")
                        currentAttributeCodePage = 0;
                    var hasAttributes = node.Attributes.Count > 0;
                    var hasContent = node.HasChildNodes;
                    var codePage = TagCodeSpace.ContainsTag(currentTagCodePage, node.Name);
                    if (codePage >= 0)
                    {
                        if (currentTagCodePage != codePage)
                        {
                            bytesList.Add((byte)GlobalTokens.Names.SWITCH_PAGE);
                            bytesList.Add((byte)codePage);
                            currentTagCodePage = codePage;
                        }

                        byte keyValue = TagCodeSpace.GetCodePage(currentTagCodePage).GetTag(node.Name).Token;
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
                        bytesList.Add((byte)GlobalTokens.Names.END);
                    }

                    if (hasContent)
                    {
                        bytesList.AddRange(EncodeNodes(node.ChildNodes));
                        bytesList.Add((byte)GlobalTokens.Names.END);
                    }
                    break;
                case XmlNodeType.Text:
                    var isOpaqueData = false;

                    if (OpaqueDataExpressions.Count > 0)
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
                        var opaqueDataBytes = GetBytes(node.Value);
                        bytesList.Add((byte)GlobalTokens.Names.OPAQUE);
                        bytesList.AddRange(GetMultiByte(opaqueDataBytes.Length));
                        bytesList.AddRange(opaqueDataBytes);
                    }
                    else
                    {
                        string textValue = node.Value;

                        while (textValue.Length > 0)
                        {
                            var stringTableIndex = textValue.Length;

                            if (StringTable.ContainsString(textValue))
                            {
                                var stringTableItem = StringTable.GetString(textValue);
                                stringTableIndex = textValue.IndexOf(stringTableItem.Value);

                                if (stringTableIndex == 0)
                                {
                                    bytesList.Add((byte)GlobalTokens.Names.STR_T);
                                    bytesList.AddRange(GetMultiByte(stringTableItem.Index));
                                    textValue = textValue.Substring(stringTableItem.Value.Length);
                                    continue;
                                }
                            }

                            bytesList.Add((byte)GlobalTokens.Names.STR_I);
                            bytesList.AddRange(Encoding.GetBytes(textValue.Substring(0, stringTableIndex)));
                            bytesList.Add(0);

                            textValue = textValue.Substring(stringTableIndex);
                        }
                    }
                    break;
                case XmlNodeType.EntityReference:
                    bytesList.Add((byte)GlobalTokens.Names.ENTITY);
                    var reference = (XmlEntityReference)node;
                    foreach (var stringItem in reference.InnerText.ToCharArray())
                    {
                        bytesList.AddRange(GetMultiByte(stringItem));
                    }
                    break;
                case XmlNodeType.Attribute:

                    var attrCodePage = AttributeCodeSpace.ContainsAttributeStart(
                        currentAttributeCodePage, node.Name, node.Value);
                    if (attrCodePage >= 0)
                    {
                        if (currentAttributeCodePage != attrCodePage)
                        {
                            bytesList.Add((byte)GlobalTokens.Names.SWITCH_PAGE);
                            bytesList.Add((byte)attrCodePage);
                            currentAttributeCodePage = attrCodePage;
                        }
                        if (AttributeCodeSpace.GetCodePage(currentAttributeCodePage).ContainsAttributeStart(node.Name,
                                                                                                            node.Value))
                        {
                            var attributeStart =
                                AttributeCodeSpace.GetCodePage(currentAttributeCodePage).GetAttributeStart(node.Name,
                                                                                                           node.Value);
                            bytesList.Add(attributeStart.Token);

                            var postAttributeValue = node.Value.Substring(attributeStart.Prefix.Length);
                            while (postAttributeValue.Length > 0)
                            {
                                int attrValueIndex = postAttributeValue.Length;

                                if (
                                    AttributeCodeSpace.GetCodePage(currentAttributeCodePage).ContainsAttributeValue(
                                        postAttributeValue))
                                {
                                    var attrValue = AttributeCodeSpace.GetCodePage(currentAttributeCodePage).GetAttributeValue(postAttributeValue);
                                    attrValueIndex = postAttributeValue.IndexOf(attrValue.Value);

                                    if (attrValueIndex == 0)
                                    {
                                        bytesList.Add(attrValue.Token);
                                        postAttributeValue = postAttributeValue.Substring(attrValue.Value.Length);
                                        continue;
                                    }
                                }

                                var stringTableIndex = postAttributeValue.Length;

                                if (StringTable.ContainsString(postAttributeValue))
                                {
                                    var stringTableItem = StringTable.GetString(postAttributeValue);
                                    stringTableIndex = postAttributeValue.IndexOf(stringTableItem.Value);

                                    if (stringTableIndex == 0)
                                    {
                                        bytesList.Add((byte)GlobalTokens.Names.STR_T);
                                        bytesList.AddRange(GetMultiByte(stringTableItem.Index));

                                        postAttributeValue = postAttributeValue.Substring(stringTableItem.Value.Length);
                                        continue;
                                    }
                                }

                                var firstReferenceIndex = Math.Min(attrValueIndex, stringTableIndex);
                                bytesList.Add((byte)GlobalTokens.Names.STR_I);
                                bytesList.AddRange(
                                    Encoding.GetBytes(postAttributeValue.Substring(0, firstReferenceIndex)));
                                bytesList.Add(0);

                                postAttributeValue = postAttributeValue.Substring(firstReferenceIndex);
                            }
                        }
                    }
                    else
                    {
                        //TODO: unknown attribute
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

            return Encoding.GetString(byteList.ToArray());
        }

        private string GetString(Queue<byte> byteQueue, int length)
        {
            var byteList = new List<byte>();
            for (int i = 0; i < length; i++)
            {
                byteList.Add(byteQueue.Dequeue());
            }
            return Encoding.GetString(byteList.ToArray());
        }

        private IEnumerable<byte> GetMultiByte(int multiByteValue)
        {
            if (multiByteValue == 0)
            {
                return new byte[] { 0x00 };
            }
            var multiByteList = new List<byte>();

            while (multiByteValue > 0)
            {
                var byteValue = 0;
                for (var i = 0; i < 7; i++)
                {
                    if (IsBitSet(multiByteValue, i))
                    {
                        byteValue += 1 << i; // 2^i == 1<<i
                    }
                }

                if (multiByteList.Count > 0)
                {
                    byteValue += 128;
                }

                multiByteList.Insert(0, (byte)byteValue);
                multiByteValue >>= 7;
            }

            return multiByteList.ToArray();
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

            var returnValue = 0;
            for (var i = 0; i < multiByteList.Count; i++)
            {
                int byteValue = multiByteList[i];
                var power = 7 * (multiByteList.Count - 1 - i);
                returnValue += byteValue * (1 << power);
            }
            return returnValue;
        }

        private IEnumerable<byte> GetByteArray(Queue<byte> messageQueue, int length)
        {
            var byteList = new List<byte>();
            for (var i = 0; i < length; i++)
            {
                byteList.Add(messageQueue.Dequeue());
            }
            return byteList.ToArray();
        }

        private byte[] GetBytes(string messageValue)
        {
            var byteList = new List<byte>();
            if (messageValue == null || messageValue.Length % 2 == 1)
            {
                return byteList.ToArray();
            }

            for (var i = 0; i < messageValue.Length / 2; i++)
            {
                byteList.Add(byte.Parse(messageValue.Substring(i * 2, 2), NumberStyles.HexNumber));
            }

            return byteList.ToArray();
        }

        private string GetEntity(int entityValue)
        {
            switch (entityValue)
            {
                case 38:
                    return "&amp;";
                case 60:
                    return "&lt;";
                case 62:
                    return "&gt;";
                case 160:
                    return "&nbsp;";
                case 161:
                    return "&iexcl;";
                case 162:
                    return "&cent;";
                case 163:
                    return "&pound;";
                case 164:
                    return "&curren;";
                case 165:
                    return "&yen;";
                case 166:
                    return "&brvbar;";
                case 167:
                    return "&sect;";
                case 168:
                    return "&uml;";
                case 169:
                    return "&copy;";
                case 170:
                    return "&ordf;";
                case 171:
                    return "&laquo;";
                case 172:
                    return "&not;";
                case 173:
                    return "&shy;";
                case 174:
                    return "&reg;";
                case 175:
                    return "&macr;";
                case 176:
                    return "&deg;";
                case 177:
                    return "&plusmn;";
                case 178:
                    return "&sup2;";
                case 179:
                    return "&sup3;";
                case 180:
                    return "&acute;";
                case 181:
                    return "&micro;";
                case 182:
                    return "&para;";
                case 183:
                    return "&middot;";
                case 184:
                    return "&cedil;";
                case 185:
                    return "&sup1;";
                case 186:
                    return "&ordm;";
                case 187:
                    return "&raquo;";
                case 188:
                    return "&frac14;";
                case 189:
                    return "&frac12;";
                case 190:
                    return "&frac34;";
                //TODO: continue from http://www.w3schools.com/charsets/ref_html_entities_4.asp
                default:
                    var entity = Convert.ToChar(entityValue).ToString(CultureInfo.InvariantCulture);
                    return WebUtility.HtmlEncode(entity);
            }
        }

        private static bool IsBitSet(int byteItem, int bitNumber)
            => (byteItem & (1 << bitNumber)) == Math.Pow(2, bitNumber);

        #endregion
    }
}