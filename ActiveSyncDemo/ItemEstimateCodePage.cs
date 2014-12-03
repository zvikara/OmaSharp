using WBXML;

namespace ActiveSyncDemo
{
    internal class ItemEstimateCodePage : TagCodePage
    {
        public ItemEstimateCodePage()
        {
            AddToken(0x05, "GetItemEstimate");
            AddToken(0x06, "Version");
            AddToken(0x07, "Collections");
            AddToken(0x08, "Collection");
            AddToken(0x09, "Class");
            AddToken(0x0A, "CollectionId");
            AddToken(0x0B, "DateTime");
            AddToken(0x0C, "Estimate");
            AddToken(0x0D, "Response");
            AddToken(0x0E, "Status");
        }
    }
}