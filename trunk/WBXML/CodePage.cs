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
    public class CodePage
    {
        private Dictionary<byte, string> tokenDictionary = new Dictionary<byte, string>();

        //Create a second dictionary for speeding up encoding
        private Dictionary<string, byte> keyDictionary;

        public void AddToken(byte identifier, String tokenName)
        {
            tokenDictionary.Add(identifier, tokenName);
        }

        public virtual bool ContainsToken(byte byteItem)
        {
            return tokenDictionary.ContainsKey(byteItem);
        }

        public virtual string GetToken(byte byteItem)
        {
            return tokenDictionary[byteItem];
        }

        public virtual bool ContainsKey(string tokenValue)
        {
            if (keyDictionary == null)
            {
                CreateKeyDictionary();
            }

            return keyDictionary.ContainsKey(tokenValue);
        }

        public virtual byte GetKey(string tokenValue)
        {
            if (keyDictionary == null)
            {
                CreateKeyDictionary();
            }

            return keyDictionary[tokenValue];
        }

        private void CreateKeyDictionary()
        {
            keyDictionary = new Dictionary<string, byte>();
            foreach (KeyValuePair<byte, string> pair in tokenDictionary)
            {
                keyDictionary.Add(pair.Value, pair.Key);
            }
        }
    }
}
