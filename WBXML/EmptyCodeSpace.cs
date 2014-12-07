namespace OmaSharp.WBXML
{
    internal class EmptyCodeSpace : TagCodeSpace
    {
        public override int GetPublicIdentifier()
        {
            return 0x01;
        }

        public override TagCodePage GetCodePage(int codepageId)
        {
            return new EmptyCodePage();
        }
    }
}