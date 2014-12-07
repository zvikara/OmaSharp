using OmaSharp.WBXML;

namespace ActiveSyncDemo
{
    internal class FolderHierarchyCodePage : TagCodePage
    {
        public FolderHierarchyCodePage()
        {
            AddToken(0x05, "Folders");
            AddToken(0x06, "Folder");
            AddToken(0x07, "DisplayName");
            AddToken(0x08, "ServerId");
            AddToken(0x09, "ParentId");
            AddToken(0x0A, "Type");
            AddToken(0x0B, "Response");
            AddToken(0x0C, "Status");
            AddToken(0x0D, "ContentClass");
            AddToken(0x0E, "Changes");
            AddToken(0x0F, "Add");
            AddToken(0x10, "Delete");
            AddToken(0x11, "Update");
            AddToken(0x12, "SyncKey");
            AddToken(0x13, "FolderCreate");
            AddToken(0x14, "FolderDelete");
            AddToken(0x15, "FolderUpdate");
            AddToken(0x16, "FolderSync");
            AddToken(0x17, "Count");
            AddToken(0x18, "Version");
        }
    }
}