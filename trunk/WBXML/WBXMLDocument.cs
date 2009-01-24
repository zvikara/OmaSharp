// Copyright 2009 - Johan de Koning (johan@johandekoning.nl)
// 
// This file is part of WBXML .Net Library.
// The WBXML .Net Library is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// The WBXML .Net Library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// The WAP Binary XML (WBXML) specification is developed by the 
// Open Mobile Alliance (http://www.openmobilealliance.org/)
// Details about this specification can be found at
// http://www.openmobilealliance.org/tech/affiliates/wap/wap-192-wbxml-20010725-a.pdf

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;

namespace WBXML
{
    public class WBXMLDocument : XmlDocument
    {
        private GlobalTokens globalTokens = new GlobalTokens();
        
        private CodeSpace tagCodeSpace = new EmptyCodeSpace();
        private AttributeCodeSpace attributeCodeSpace = new AttributeCodeSpace();
        private Encoding textEncoding = Encoding.UTF8;
        private double versionNumber;
        private int publicIdentifier;

        public double VersionNumber
        {
            get
            {
                return this.versionNumber;
            }
            set
            {
                this.versionNumber = value;
            }
        }

        public int PublicIdentifier
        {
            get
            {
                return this.publicIdentifier;
            }
            set
            {
                this.publicIdentifier = value;
            }
        }

        public Encoding Encoding
        {
            get
            {
                return this.textEncoding;
            }
            set
            {
                this.textEncoding = value;
            }
        }

        public CodeSpace TagCodeSpace
        {
            get
            {
                return this.tagCodeSpace;
            }
            set
            {
                this.tagCodeSpace = value;
            }
        }

        public AttributeCodeSpace AttributeCodeSpace
        {
            get
            {
                return this.attributeCodeSpace;
            }
            set
            {
                this.attributeCodeSpace = value;
            }
        }

        public void LoadBytes(byte[] bytes)
        {
            DecodeWBXML(bytes);
        }

        #region Decoder
        private void DecodeWBXML(byte[] bytes)
        {
            tagCodeSpace.SwitchCodePage(0);
            attributeCodeSpace.SwitchCodePage(0);

            XmlNode activeNode = this;

            Queue<byte> byteQueue = new Queue<byte>(bytes);

            //Get the WBXML version number;
            versionNumber = ((double)byteQueue.Dequeue() / 10.0) + 1.0;

            //Get the value of the public identifier
            publicIdentifier = GetInt(byteQueue);

            //Get the charset for text encoding (not implemented, UTF 8 is used)
            int charset = GetInt(byteQueue);

            XmlDeclaration declaration = CreateXmlDeclaration("1.0", textEncoding.WebName, null);
            activeNode.AppendChild(declaration);

            //Get the string table (use of the string table is not implemented)
            int stringTableLength = GetInt(byteQueue);
            string stringTable = GetString(byteQueue, stringTableLength);

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
                            tagCodeSpace.SwitchCodePage((int)byteQueue.Dequeue());
                            break;
                        case GlobalTokens.Names.END:
                            activeNode = activeNode.ParentNode;
                            break;
                        case GlobalTokens.Names.ENTITY:
                            //TODO ENTITY is not implemented yet
                            int entityLength = GetInt(byteQueue);
                            break;
                        case GlobalTokens.Names.STR_I:
                            activeNode.AppendChild(CreateTextNode(GetString(byteQueue)));
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
                            List<byte> piByteList = new List<byte>();
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
                            int exttReference = GetInt(byteQueue);
                            break;
                        case GlobalTokens.Names.STR_T:
                            //TODO STR_T is not implemented yet
                            int strtReference = GetInt(byteQueue);
                            break;
                        case GlobalTokens.Names.EXT_0:
                        case GlobalTokens.Names.EXT_1:
                        case GlobalTokens.Names.EXT_2:
                            //TODO EXT_x are not implemented yet
                            break;
                        case GlobalTokens.Names.OPAQUE:
                            int opaqueLength = GetInt(byteQueue);
                            byte[] opaqueByteArray = GetByteArray(byteQueue, opaqueLength);
                            List<string> opaqueHexList = new List<string>();
                            foreach (byte opaqueByteItem in opaqueByteArray)
                            {
                                opaqueHexList.Add(opaqueByteItem.ToString("X2"));
                            }
                            activeNode.InnerText = String.Join("", opaqueHexList.ToArray());
                            break;
                    }
                }
                else
                {
                    bool tagHasAttributes = IsBitSet(byteItem, 7);
                    bool tagHasContent = IsBitSet(byteItem, 6);

                    byteItem &= 127;
                    byteItem &= 63;

                    string tagValue;
                    if (tagCodeSpace.GetCodePage().ContainsToken(byteItem))
                    {
                        tagValue = tagCodeSpace.GetCodePage().GetName(byteItem);
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
                    }
                }
            }
        }
        #endregion

        #region Encoder
        public byte[] GetBytes()
        {
            List<byte> bytesList = new List<byte>();

            //Versionnumber
            bytesList.Add((byte)((int)((versionNumber * 10) - 10)));

            //Public identifier (currently implemented as unknown)
            bytesList.Add(0x01);

            //Encoding (currently implemented as US-ASCII
            bytesList.Add(0x03);
            textEncoding = Encoding.GetEncoding("us-ascii");

            //String table length (currently implemented as empty string table
            bytesList.Add(0x00);

            bytesList.AddRange(EncodeNodes(this.ChildNodes));

            return bytesList.ToArray();
        }

        private byte[] EncodeNodes(XmlNodeList nodes)
        {
            List<byte> bytesList = new List<byte>();

            foreach (XmlNode node in nodes)
            {
                bytesList.AddRange(EncodeNode(node));
            }

            return bytesList.ToArray();
        }

        private byte[] EncodeNode(XmlNode node)
        {
            List<byte> bytesList = new List<byte>();

            Console.WriteLine(node.NodeType);
            switch (node.NodeType)
            {
                case XmlNodeType.Element:
                    bool hasAttributes = node.Attributes.Count > 0;
                    bool hasContent = node.HasChildNodes;
                    if (tagCodeSpace.GetCodePage().ContainsName(node.Name))
                    {
                        byte keyValue = tagCodeSpace.GetCodePage().GetToken(node.Name);
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
                    bytesList.Add((byte)GlobalTokens.Names.STR_I);
                    bytesList.AddRange(textEncoding.GetBytes(node.Value));
                    bytesList.Add(0x00);
                    break;
                case XmlNodeType.EntityReference:
                    bytesList.Add((byte)GlobalTokens.Names.ENTITY);
                    XmlEntityReference reference = (XmlEntityReference)node;
                    foreach (int stringItem in reference.InnerText.ToCharArray())
                    {
                        bytesList.AddRange(GetMultiByte(stringItem));
                    }
                    break;
                case XmlNodeType.Attribute:
                    Console.WriteLine(node.Name);
                    Console.WriteLine(node.Value);
                    if (attributeCodeSpace.GetCodePage().ContainsAttributeStartName(node.Name, node.Value))
                    {
                        bytesList.Add(attributeCodeSpace.GetCodePage().GetAttributeStartToken(node.Name, node.Value));
                    }
                    else if (attributeCodeSpace.GetCodePage().ContainsAttributeStartName(node.Name))
                    {
                        bytesList.Add(attributeCodeSpace.GetCodePage().GetAttributeStartToken(node.Name));
                    }
                    else
                    {
                        Console.WriteLine("Unknown attribute");
                    }
                    break;
            }

            return bytesList.ToArray();
        }
        #endregion


        #region Util Methods
        private string GetString(Queue<byte> byteQueue)
        {
            List<byte> byteList = new List<byte>();
            while (byteQueue.Peek() != 0)
            {
                byteList.Add(byteQueue.Dequeue());
            }
            byteQueue.Dequeue();

            return textEncoding.GetString(byteList.ToArray());
        }

        private string GetString(Queue<byte> byteQueue, int length)
        {
            List<byte> byteList = new List<byte>();
            for (int i = 0; i < length; i++)
            {
                byteList.Add(byteQueue.Dequeue());
            }
            return textEncoding.GetString(byteList.ToArray());
        }

        private byte[] GetMultiByte(int multiByteValue)
        {
            List<byte> multiByteList = new List<byte>();

            while (multiByteValue > 0)
            {
                int byteValue = 0;
                for (int i = 0; i < 7; i++)
                {
                    if (IsBitSet(multiByteValue, i))
                    {
                        byteValue += (int)Math.Pow(2, i);
                    }
                }

                if (multiByteList.Count > 0)
                {
                    byteValue += 128;
                }

                multiByteList.Insert(0,(byte)byteValue);
                multiByteValue >>= 7;
            }

            return multiByteList.ToArray();
        }

        private int GetInt(Queue<byte> byteQueue)
        {
            List<byte> multiByteList = new List<byte>();
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
                int byteValue = (int)multiByteList[i];
                double power = 7 * (multiByteList.Count - 1 - i);
                returnValue += (int)(byteValue * Math.Pow(2, power));
            }
            return returnValue;
        }

        private byte[] GetByteArray(Queue<byte> messageQueue, int length)
        {
            List<byte> byteList = new List<byte>();
            for (int i = 0; i < length; i++)
            {
                byteList.Add(messageQueue.Dequeue());
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
