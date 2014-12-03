using WBXML;

namespace ActiveSyncDemo
{
    public class MoveCodePage : TagCodePage
    {
        public MoveCodePage()
        {
            AddToken(0x05, "MoveItems");
            AddToken(0x06, "Move");
            AddToken(0x07, "SrcMsgId");
            AddToken(0x08, "SrcFldId");
            AddToken(0x09, "DstFldId");
            AddToken(0x0A, "Response");
            AddToken(0x0B, "Status");
            AddToken(0x0C, "DstMsgId");
        }
    }
}