using WBXML;

namespace ActiveSyncDemo
{
    internal class Contacts2CodePage : TagCodePage
    {
        public Contacts2CodePage()
        {
            AddToken(0x05, "CustomerId");
            AddToken(0x06, "GovernmentId");
            AddToken(0x07, "IMAddress");
            AddToken(0x08, "IMAddress2");
            AddToken(0x09, "IMAddress3");
            AddToken(0x0A, "ManagerName");
            AddToken(0x0B, "CompanyMainPhone");
            AddToken(0x0C, "AccountName");
            AddToken(0x0D, "NickName");
            AddToken(0x0E, "MMS");
        }
    }
}