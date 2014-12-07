using OmaSharp.WBXML;

namespace ActiveSyncDemo
{
    internal class PingCodePage : TagCodePage
    {
        public PingCodePage()
        {
            AddToken(0x05, "Ping");
            AddToken(0x06, "AutdState");
            AddToken(0x07, "Status");
            AddToken(0x08, "HeartbeatInterval");
            AddToken(0x09, "Folders");
            AddToken(0x0A, "Folder");
            AddToken(0x0B, "Id");
            AddToken(0x0C, "Class");
            AddToken(0x0D, "MaxFolders");
        }
    }
}