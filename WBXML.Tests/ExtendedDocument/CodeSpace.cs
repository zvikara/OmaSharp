// Encoding sample which can be found inside section 8.2 of the WBXML Specification

namespace WBXML.Tests.ExtendedDocument
{
    public class CodeSpace : TagCodeSpace
    {
        public CodeSpace()
        {
            var codePage = new TagCodePage();
            codePage.AddToken(0x05, "CARD");
            codePage.AddToken(0x06, "INPUT");
            codePage.AddToken(0x07, "XYZ");
            codePage.AddToken(0x08, "DO");
            AddCodePage(codePage);
        }

        public override int GetPublicIdentifier()
        {
            return 0x01;
        }
    }
}