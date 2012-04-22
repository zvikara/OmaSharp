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
    public class TagCodePage
    {
        private readonly Dictionary<string, byte> nameDictionary = new Dictionary<string, byte>();
        private readonly Dictionary<byte, string> tokenDictionary = new Dictionary<byte, string>();

        public void AddToken(byte token, string name)
        {
            tokenDictionary.Add(token, name);
            nameDictionary.Add(name, token);
        }

        public virtual bool ContainsTag(byte token)
        {
            return tokenDictionary.ContainsKey(token);
        }

        public virtual bool ContainsTag(string name)
        {
            return nameDictionary.ContainsKey(name);
        }

        public virtual Tag GetTag(byte token)
        {
            return new Tag(token, tokenDictionary[token]);
        }

        public virtual Tag GetTag(string name)
        {
            return new Tag(nameDictionary[name], name);
        }
    }
}