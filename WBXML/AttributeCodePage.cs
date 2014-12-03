// Copyright 2012 - Johan de Koning (johan@johandekoning.nl)
// 
// This file is part of WBXML .Net Library.
// Permission is hereby granted, free of charge, to any person obtaining a copy 
// of this software and associated documentation files (the "Software"), to deal in 
// the Software without restriction, including without limitation the rights to use, 
// copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the 
// Software, and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies 
// or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE 
// USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// The WAP Binary XML (WBXML) specification is developed by the 
// Open Mobile Alliance (http://www.openmobilealliance.org/)
// Details about this specification can be found at
// http://www.openmobilealliance.org/tech/affiliates/wap/wap-192-wbxml-20010725-a.pdf

using System.Collections.Generic;

namespace WBXML
{
    public class AttributeCodePage
    {
        private readonly Dictionary<string, Dictionary<string, byte>> attrStartNameDictionary =
            new Dictionary<string, Dictionary<string, byte>>();

        private readonly Dictionary<byte, AttributeStart> attrStartTokenDictionary =
            new Dictionary<byte, AttributeStart>();

        private readonly Dictionary<string, byte> attrValueNameDictionary = new Dictionary<string, byte>();
        private readonly Dictionary<byte, string> attrValueTokenDictionary = new Dictionary<byte, string>();

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
                if (attributeValue.Contains(attributeValueItem))
                {
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
                if (attributeValue.Contains(attributeValueItem))
                {
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
                if (prefix.StartsWith(prefixItem))
                {
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