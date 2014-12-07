using OmaSharp.WBXML;

namespace ActiveSyncDemo
{
    internal class NotesCodePage : TagCodePage
    {
        public NotesCodePage()
        {
            AddToken(0x05, "Subject");
            AddToken(0x06, "MessageClass");
            AddToken(0x07, "LastModifiedDate");
            AddToken(0x08, "Categories");
            AddToken(0x09, "Category");
        }
    }
}