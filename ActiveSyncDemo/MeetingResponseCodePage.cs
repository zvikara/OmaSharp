using OmaSharp.WBXML;

namespace ActiveSyncDemo
{
    internal class MeetingResponseCodePage : TagCodePage
    {
        public MeetingResponseCodePage()
        {
            AddToken(0x05, "CalId");
            AddToken(0x06, "CollectionId");
            AddToken(0x07, "MeetingResponse");
            AddToken(0x08, "ReqId");
            AddToken(0x09, "Request");
            AddToken(0x0A, "Result");
            AddToken(0x0B, "Status");
            AddToken(0x0C, "UserResponse");
            AddToken(0x0D, "Version");
        }
    }
}