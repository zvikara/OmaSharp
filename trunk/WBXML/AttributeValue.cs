using System;
using System.Collections.Generic;
using System.Text;

namespace WBXML
{
    public class AttributeValue
    {
        private byte token;
        private string attributeValue;

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
                return attributeValue;
            }
        }

        public AttributeValue(byte token, string attributeValue)
        {
            this.token = token;
            this.attributeValue = attributeValue;
        }
    }
}
