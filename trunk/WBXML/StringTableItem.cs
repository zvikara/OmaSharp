using System;
using System.Collections.Generic;
using System.Text;

namespace WBXML
{
    public class StringTableItem
    {
        private byte token;
        private string itemValue;

        public byte Token
        {
            get
            {
                return token;
            }
        }

        public string Value
        {
            get
            {
                return itemValue;
            }
        }

        public StringTableItem(byte token, string itemValue)
        {
            this.token = token;
            this.itemValue = itemValue;
        }
    }
}
