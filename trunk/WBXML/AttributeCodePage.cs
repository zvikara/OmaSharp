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
            attrStartTokenDictionary.Add(token, new AttributeStart(attributeName, prefixValue));

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

        public virtual bool ContainsToken(byte token)
        {
            if (token >= 128)
            {
                return attrValueTokenDictionary.ContainsKey(token);
            }
            else
            {
                return attrStartTokenDictionary.ContainsKey(token);
            }
        }

        public virtual bool ContainsAttributeStartName(string name)
        {
            return ContainsAttributeStartName(name, "");
        }

        public virtual bool ContainsAttributeStartName(string name, string prefix)
        {
            if(attrStartNameDictionary.ContainsKey(name)){
                foreach(string attributePrefix in attrStartNameDictionary[name].Keys){
                    if(prefix.StartsWith(attributePrefix)){
                        return true;
                    }
                }
            }
            return false;
        }

        /*public virtual bool ContainsAttributeValueName(string attributeValue)
        {
            return attrValueNameDictionary.ContainsKey(attributeValue);
        }*/

        public virtual string GetAttributeValue(byte token)
        {
            return attrValueTokenDictionary[token];
        }

        public virtual AttributeStart GetAttributeStart(byte token)
        {
            return attrStartTokenDictionary[token];
        }

        public virtual byte GetAttributeStartToken(string name)
        {
            return GetAttributeStartToken(name, "");
        }

        public virtual byte GetAttributeStartToken(string name, string prefix)
        {
            foreach (string attributePrefix in attrStartNameDictionary[name].Keys)
            {
                if (prefix.StartsWith(attributePrefix))
                {
                    return attrStartNameDictionary[name][attributePrefix];
                }
            }

            //TODO throw an exception
            return 0;
        }

        public int IndexOfAttributeValue(string attributeValue)
        {
            int index = -1;
            foreach (string item in attrValueNameDictionary.Keys)
            {
                if (attributeValue.IndexOf(item) > -1)
                {
                    if (index < 0)
                    {
                        index = attributeValue.IndexOf(item);
                    }
                    else
                    {
                        index = Math.Min(index, attributeValue.IndexOf(item));
                    }
                };
            }

            return index;
        }

        public virtual byte GetAttributeValueToken(string attributeValue)
        {
            int index = IndexOfAttributeValue(attributeValue);
            foreach (string item in attrValueNameDictionary.Keys)
            {
                if (attributeValue.Substring(index).StartsWith(item))
                {
                    return attrValueNameDictionary[item];
                }
            }
            
            //TODO throw an exception
            return 0;
        }
    }
}
