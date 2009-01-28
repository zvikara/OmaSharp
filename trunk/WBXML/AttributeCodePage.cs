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

namespace WBXML
{
    public class AttributeCodePage
    {
        private Dictionary<byte, AttributeStart> attrStartTokenDictionary = new Dictionary<byte, AttributeStart>();
        private Dictionary<byte, string> attrValueTokenDictionary = new Dictionary<byte, string>();

        private Dictionary<string, byte> attrValueNameDictionary = new Dictionary<string, byte>();
        private Dictionary<string, Dictionary<string, byte>> attrStartNameDictionary =  new Dictionary<string, Dictionary<string,byte>>();

        public void AddAttributeStart(byte token, string attributeName)
        {
            AddAttributeStart(token, attributeName, "");
        }

        public void AddAttributeStart(byte token, string attributeName, string prefixValue)
        {
            attrStartTokenDictionary.Add(token, new AttributeStart(token, attributeName, prefixValue));

            Dictionary<string, byte> internalValueTokenDictionary;
            if (attrStartNameDictionary.ContainsKey(attributeName))
            {
                internalValueTokenDictionary = attrStartNameDictionary[attributeName];
            }
            else
            {
                internalValueTokenDictionary = new Dictionary<string, byte>();
                attrStartNameDictionary.Add(attributeName, internalValueTokenDictionary);
            }

            internalValueTokenDictionary.Add(prefixValue, token);
        }

        public void AddAttributeValue(byte token, string attributeValue)
        {
            attrValueTokenDictionary.Add(token, attributeValue);
            attrValueNameDictionary.Add(attributeValue, token);
        }

        public virtual bool ContainsAttributeStart(byte token)
        {
            if (token < 128)
            {
                return attrStartTokenDictionary.ContainsKey(token);
            }

            return false;
        }

        public virtual bool ContainsAttributeStart(string name)
        {
            return ContainsAttributeStart(name, "");
        }

        public virtual bool ContainsAttributeStart(string name, string attributeValue)
        {
            if (attrStartNameDictionary.ContainsKey(name))
            {
                foreach (string prefixItem in attrStartNameDictionary[name].Keys)
                {
                    if (attributeValue.StartsWith(prefixItem))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public virtual bool ContainsAttributeValue(byte token)
        {
            if (token >= 128)
            {
                return attrValueTokenDictionary.ContainsKey(token);
            }

            return false;
        }

        public virtual bool ContainsAttributeValue(string attributeValue)
        {
            foreach (string attributeValueItem in attrValueNameDictionary.Keys)
            {
                if(attributeValue.Contains(attributeValueItem)){
                    return true;
                }
            }

            return false;
        }

        public virtual AttributeValue GetAttributeValue(byte token)
        {
            return new AttributeValue(token, attrValueTokenDictionary[token]);
        }

        public virtual AttributeValue GetAttributeValue(string attributeValue)
        {
            AttributeValue returnValue = null;

            foreach (string attributeValueItem in attrValueNameDictionary.Keys)
            {
                if(attributeValue.Contains(attributeValueItem)){
                    if (returnValue == null 
                        || attributeValue.IndexOf(attributeValueItem) < attributeValue.IndexOf(returnValue.Value) 
                        || attributeValueItem.Length > returnValue.Value.Length)
                    {
                        returnValue = new AttributeValue(attrValueNameDictionary[attributeValueItem], attributeValueItem);
                    }
                }
            }

            return returnValue;
        }

        public virtual AttributeStart GetAttributeStart(byte token)
        {
            return attrStartTokenDictionary[token];
        }

        public virtual AttributeStart GetAttributeStart(string name, string prefix)
        {
            AttributeStart returnValue = null;
            
            foreach (string prefixItem in attrStartNameDictionary[name].Keys)
            {
                if(prefix.StartsWith(prefixItem)){
                    if (returnValue == null || prefixItem.Length > returnValue.Prefix.Length)
                    {
                        returnValue = new AttributeStart(attrStartNameDictionary[name][prefixItem], name, prefixItem);
                    }
                }
            }

            return returnValue;
        }
    }
}
