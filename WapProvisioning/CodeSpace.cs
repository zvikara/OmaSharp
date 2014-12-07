using WBXML;

namespace WapProvisioning
{
    public class CodeSpace : TagCodeSpace
    {
        public CodeSpace()
        {
            AddCodePage(new TagCodePage0());
            AddCodePage(new TagCodePage1());
        }

        public override int GetPublicIdentifier()
        {
            return 0x0b;
        }
    }
}