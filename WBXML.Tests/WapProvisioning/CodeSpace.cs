namespace WBXML.Tests.WapProvisioning
{
    public class CodeSpace : TagCodeSpace
    {
        public CodeSpace()
        {
            AddCodePage(GetCodePage0());
            AddCodePage(GetCodePage1());
        }

        private static TagCodePage GetCodePage0()
        {
            var codePage = new TagCodePage();
            codePage.AddToken(0x05, "wap-provisioningdoc");
            codePage.AddToken(0x06, "characteristic");
            codePage.AddToken(0x07, "parm");
            return codePage;
        }

        private static TagCodePage GetCodePage1()
        {
            var codePage = new TagCodePage();
            codePage.AddToken(0x06, "characteristic");
            codePage.AddToken(0x07, "parm");
            return codePage;
        }

        public override int GetPublicIdentifier()
        {
            return 0x0b;
        }
    }
}