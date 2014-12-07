using OmaSharp.WBXML;

namespace OmaSharp.WapProvisioning
{
    public class TagCodePage0 : TagCodePage
    {
        public TagCodePage0()
        {
            AddToken(0x05, "wap-provisioningdoc");
            AddToken(0x06, "characteristic");
            AddToken(0x07, "parm");
        }
    }
}
