using WBXML;

namespace WapProvisioning
{
    public class TagCodePage1 : TagCodePage
    {
        public TagCodePage1()
        {
            AddToken(0x06, "characteristic");
            AddToken(0x07, "parm");
        }
    }
}
