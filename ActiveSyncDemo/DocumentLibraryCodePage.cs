using WBXML;

namespace ActiveSyncDemo
{
    internal class DocumentLibraryCodePage : TagCodePage
    {
        public DocumentLibraryCodePage()
        {
            AddToken(0x05, "LinkId");
            AddToken(0x06, "DisplayName");
            AddToken(0x07, "IsFolder");
            AddToken(0x08, "CreationDate");
            AddToken(0x09, "LastModifiedDate");
            AddToken(0x0A, "IsHidden");
            AddToken(0x0B, "ContentLength");
            AddToken(0x0C, "ContentType");
        }
    }
}