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


using System;
using System.Collections.Generic;

namespace WBXML
{
    public class GlobalTokens
    {
        #region Names enum

        public enum Names
        {
            SWITCH_PAGE = 0x00,
            END = 0x01,
            ENTITY = 0x02,
            STR_I = 0x03,
            LITERAL = 0x04,
            EXT_I_0 = 0x40,
            EXT_I_1 = 0x41,
            EXT_I_2 = 0x42,
            PI = 0x43,
            LITERAL_C = 0x44,
            EXT_T_0 = 0x80,
            EXT_T_1 = 0x81,
            EXT_T_2 = 0x82,
            STR_T = 0x83,
            LITERAL_A = 0x84,
            EXT_0 = 0xC0,
            EXT_1 = 0xC1,
            EXT_2 = 0xC2,
            OPAQUE = 0xC3,
            LITERAL_AC = 0xC4
        }

        #endregion

        private readonly Dictionary<byte, Names> tokenDictionary = new Dictionary<byte, Names>();

        public GlobalTokens()
        {
            foreach (String tokenName in Enum.GetNames(typeof (Names)))
            {
                var tokenItem = (Names) Enum.Parse(typeof (Names), tokenName);
                tokenDictionary.Add((byte) tokenItem, tokenItem);
            }
        }

        public bool Contains(byte keyValue)
        {
            return tokenDictionary.ContainsKey(keyValue);
        }

        public Names GetToken(byte byteValue)
        {
            return tokenDictionary[byteValue];
        }
    }
}