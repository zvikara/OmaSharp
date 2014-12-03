// Encoding sample which can be found inside section 8.2 of the WBXML Specification
using WBXML;

namespace WBXMLSpecifcationDemo
{
    public class ExtendedAttributeCodeSpace : AttributeCodeSpace
    {
        public ExtendedAttributeCodeSpace()
        {
            var codePage = new AttributeCodePage();
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