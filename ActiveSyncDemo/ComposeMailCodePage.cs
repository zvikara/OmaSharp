using OmaSharp.WBXML;

namespace ActiveSyncDemo
{
    internal class ComposeMailCodePage : TagCodePage
    {
        public ComposeMailCodePage()
        {
            AddToken(0x05, "SendMail");
            AddToken(0x06, "SmartForward");
            AddToken(0x07, "SmartReply");
            AddToken(0x08, "SaveInSentItems");
            AddToken(0x09, "ReplaceMime");
            AddToken(0x0A, "Type");
            AddToken(0x0B, "Source");
            AddToken(0x0C, "FolderId");
            AddToken(0x0D, "ItemId");
            AddToken(0x0E, "LongId");
            AddToken(0x0F, "InstanceId");
            AddToken(0x10, "Mime");
            AddToken(0x11, "ClientId");
            AddToken(0x12, "Status");
        }
    }
}