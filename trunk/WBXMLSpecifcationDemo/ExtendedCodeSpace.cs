using System;
using System.Collections.Generic;
using System.Text;
using WBXML;

namespace WBXMLSpecifcationDemo
{
    public class ExtendedCodeSpace : CodeSpace
    {
        public ExtendedCodeSpace()
        {
            CodePage codePage = new CodePage();
            codePage.AddToken(0x05, "CARD");
            codePage.AddToken(0x06, "INPUT");
            codePage.AddToken(0x07, "XYZ");
            codePage.AddToken(0x08, "DO");

            AddCodePage(codePage);
        }
    }
}
