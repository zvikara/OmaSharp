using System;
using System.Collections.Generic;
using System.Text;

namespace WBXML
{
    public class Tag
    {
        private byte token;
        private string name;

        public byte Token
        {
            get
            {
                return token;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Tag(byte token, string name)
        {
            this.token = token;
            this.name = name;
        }
    }
}
