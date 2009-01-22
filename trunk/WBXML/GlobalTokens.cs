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
    public class GlobalTokens
    {
        private Dictionary<byte, Names> tokenDictionary = new Dictionary<byte, Names>();

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

        public GlobalTokens()
        {
           foreach(String tokenName in Enum.GetNames(typeof(Names))){
               Names tokenItem = (Names)Enum.Parse(typeof(Names), tokenName);
               tokenDictionary.Add((byte)tokenItem, tokenItem);
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
