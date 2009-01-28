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
    public class StringTable
    {
        private Dictionary<int, string> stringTableIndexDictionary = new Dictionary<int, string>();
        private Dictionary<string, int> stringTableValueDictionary = new Dictionary<string, int>();
        private int stringTableLength = 0;

        public int Length
        {
            get
            {
                return stringTableLength;
            }
        }

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
            List<byte> stringTableBytes = new List<byte>();

            foreach (string item in stringTableValueDictionary.Keys)
            {
                stringTableBytes.AddRange(textEncoding.GetBytes(item));
                stringTableBytes.Add(0x00);
            }

            return stringTableBytes.ToArray();
        }

    }
}
