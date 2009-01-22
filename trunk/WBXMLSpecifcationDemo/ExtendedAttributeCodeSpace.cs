using System;
using System.Collections.Generic;
using System.Text;
using WBXML;

namespace WBXMLSpecifcationDemo
{
    public class ExtendedAttributeCodeSpace : AttributeCodeSpace
    {
        public ExtendedAttributeCodeSpace()
        {
            AttributeCodePage codePage = new AttributeCodePage();
            codePage.AddAttributeStart(0x05, "STYLE", "LIST");
            codePage.AddAttributeStart(0x06, "TYPE");
            codePage.AddAttributeStart(0x07, "TYPE", "TEXT");
            codePage.AddAttributeStart(0x08, "URL", "http://");
            codePage.AddAttributeStart(0x09, "NAME");
            codePage.AddAttributeStart(0x0A, "KEY");

            codePage.AddAttributeValue(0x85, ".org");
            codePage.AddAttributeValue(0x86, "ACCEPT");

            AddCodePage(codePage);
        }
    }
}
