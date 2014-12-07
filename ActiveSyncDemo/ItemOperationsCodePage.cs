using OmaSharp.WBXML;

namespace ActiveSyncDemo
{
    internal class ItemOperationsCodePage : TagCodePage
    {
        public ItemOperationsCodePage()
        {
            AddToken(0x05, "ItemOperations");
            AddToken(0x06, "Fetch");
            AddToken(0x07, "Store");
            AddToken(0x08, "Options");
            AddToken(0x09, "Range");
            AddToken(0x0A, "Total");
            AddToken(0x0B, "Properties");
            AddToken(0x0C, "Data");
            AddToken(0x0D, "Status");
            AddToken(0x0E, "Response");
            AddToken(0x0F, "Version");
            AddToken(0x10, "Schema");
            AddToken(0x11, "Part");
            AddToken(0x12, "EmptyFolderContents");
            AddToken(0x13, "DeleteSubFolders");
            AddToken(0x14, "UserName");
            AddToken(0x15, "Password");
            AddToken(0x16, "Move");
            AddToken(0x17, "DstFldId");
            AddToken(0x18, "ConversationId");
            AddToken(0x19, "MoveAlways");
        }
    }
}