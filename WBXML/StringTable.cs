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
using System.Text;

namespace WBXML
{
    public class StringTable
    {
        private readonly Dictionary<int, string> stringTableIndexDictionary = new Dictionary<int, string>();
        private readonly int stringTableLength;
        private readonly Dictionary<string, int> stringTableValueDictionary = new Dictionary<string, int>();

        public StringTable()
        {
            stringTableLength = 0;
        }

        public StringTable(string[] stringTableItems)
        {
            int stringTableIndex = 0;
            foreach (string item in stringTableItems)
            {
                stringTableIndexDictionary.Add(stringTableIndex, item);
                stringTableValueDictionary.Add(item, stringTableIndex);

                stringTableIndex += item.Length + 1;
            }
            stringTableLength = stringTableIndex;
        }

        public int Length
        {
            get { return stringTableLength; }
        }

        public bool ContainsString(int index)
        {
            return stringTableIndexDictionary.ContainsKey(index);
        }

        public bool ContainsString(string stringTableValue)
        {
            foreach (string stringTableItem in stringTableValueDictionary.Keys)
            {
                if (stringTableValue.Contains(stringTableItem))
                {
                    return true;
                }
            }

            return false;
        }

        public StringTableItem GetString(string stringTableValue)
        {
            StringTableItem returnValue = null;

            foreach (string stringTableItem in stringTableValueDictionary.Keys)
            {
                if (stringTableValue.Contains(stringTableItem))
                {
                    if (returnValue == null
                        || stringTableValue.IndexOf(stringTableItem) < stringTableValue.IndexOf(returnValue.Value)
                        || stringTableItem.Length > returnValue.Value.Length)
                    {
                        returnValue = new StringTableItem(stringTableValueDictionary[stringTableItem], stringTableItem);
                    }
                }
            }

            return returnValue;
        }

        public StringTableItem GetString(int index)
        {
            return new StringTableItem(index, stringTableIndexDictionary[index]);
        }

        public byte[] GetStringTableBytes(Encoding textEncoding)
        {
            var stringTableBytes = new List<byte>();

            foreach (string item in stringTableValueDictionary.Keys)
            {
                stringTableBytes.AddRange(textEncoding.GetBytes(item));
                stringTableBytes.Add(0x00);
            }

            return stringTableBytes.ToArray();
        }
    }
}