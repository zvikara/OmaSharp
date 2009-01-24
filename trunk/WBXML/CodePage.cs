﻿// Copyright 2009 - Johan de Koning (johan@johandekoning.nl)
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
        private Dictionary<string, byte> nameDictionary = new Dictionary<string,byte>();

        public void AddToken(byte token, string name)
        {
            tokenDictionary.Add(token, name);
            nameDictionary.Add(name, token);
        }

        public virtual bool ContainsToken(byte token)
        {
            return tokenDictionary.ContainsKey(token);
        }

        public virtual bool ContainsName(string name)
        {
            return nameDictionary.ContainsKey(name);
        } 

        public virtual string GetName(byte token)
        {
            return tokenDictionary[token];
        }

        public virtual byte GetToken(string name)
        {
            return nameDictionary[name];
        }
    }
}
