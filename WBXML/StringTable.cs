using System.Collections.Generic;
using System.Text;

namespace OmaSharp.WBXML
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