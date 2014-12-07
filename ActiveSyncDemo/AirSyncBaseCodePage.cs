using OmaSharp.WBXML;

namespace ActiveSyncDemo
{
    internal class AirSyncBaseCodePage : TagCodePage
    {
        public AirSyncBaseCodePage()
        {
            AddToken(0x05, "BodyPreference");
            AddToken(0x06, "Type");
            AddToken(0x07, "TruncationSize");
            AddToken(0x08, "AllOrNone");
            AddToken(0x0A, "Body");
            AddToken(0x0B, "Data");
            AddToken(0x0C, "EstimatedDataSize");
            AddToken(0x0D, "Truncated");
            AddToken(0x0E, "Attachments");
            AddToken(0x0F, "Attachment");
            AddToken(0x10, "DisplayName");
            AddToken(0x11, "FileReference");
            AddToken(0x12, "Method");
            AddToken(0x13, "ContentId");
            AddToken(0x14, "ContentLocation");
            AddToken(0x15, "IsInline");
            AddToken(0x16, "NativeBodyType");
            AddToken(0x17, "ContentType");
            AddToken(0x18, "Preview");
        }
    }
}