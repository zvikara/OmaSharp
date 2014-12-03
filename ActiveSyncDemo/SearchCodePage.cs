using WBXML;

namespace ActiveSyncDemo
{
    internal class SearchCodePage : TagCodePage
    {
        public SearchCodePage()
        {
            //Tokens 6 and 16 are not supported
            AddToken(0x05, "Search");
            AddToken(0x07, "Store");
            AddToken(0x08, "Name");
            AddToken(0x09, "Query");
            AddToken(0x0A, "Options");
            AddToken(0x0B, "Range");
            AddToken(0x0C, "Status");
            AddToken(0x0D, "Response");
            AddToken(0x0E, "Result");
            AddToken(0x0F, "Properties");
            AddToken(0x10, "Total");
            AddToken(0x11, "EqualTo");
            AddToken(0x12, "Value");
            AddToken(0x13, "And");
            AddToken(0x14, "Or");
            AddToken(0x15, "FreeText");
            AddToken(0x17, "DeepTraversal");
            AddToken(0x18, "LongId");
            AddToken(0x19, "RebuildResults");
            AddToken(0x1A, "LessThan");
            AddToken(0x1B, "GreaterThan");
            AddToken(0x1C, "Schema");
            AddToken(0x1D, "Supported");
            AddToken(0x1E, "UserName");
            AddToken(0x1F, "Password");
            AddToken(0x20, "ConversationId");
        }
    }
}