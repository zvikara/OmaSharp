// Encoding sample which can be found inside section 8.1 of the WBXML Specification

namespace WBXML.Tests.SimpleDocument
{
    public class CodeSpace : TagCodeSpace
    {
        public CodeSpace()
        {
            var codePage = new TagCodePage();
            codePage.AddToken(0x05, "BR");
            codePage.AddToken(0x06, "CARD");
            codePage.AddToken(0x07, "XYZ");
            AddCodePage(codePage);
        }

        public override int GetPublicIdentifier()
        {
            return 0x01;
        }
    }
}