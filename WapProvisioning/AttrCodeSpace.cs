namespace WapProvisioning
{
    public class AttrCodeSpace : WBXML.AttributeCodeSpace
    {
        public AttrCodeSpace()
        {
            AddCodePage(new AttributeCodePage0());
            AddCodePage(new AttributeCodePage1());
        }
    }
}