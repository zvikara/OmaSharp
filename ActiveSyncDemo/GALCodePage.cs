using OmaSharp.WBXML;

namespace ActiveSyncDemo
{
    internal class GALCodePage : TagCodePage
    {
        public GALCodePage()
        {
            AddToken(0x05, "DisplayName");
            AddToken(0x06, "Phone");
            AddToken(0x07, "Office");
            AddToken(0x08, "Title");
            AddToken(0x09, "Company");
            AddToken(0x0A, "Alias");
            AddToken(0x0B, "FirstName");
            AddToken(0x0C, "LastName");
            AddToken(0x0D, "HomePhone");
            AddToken(0x0E, "MobilePhone");
            AddToken(0x0F, "EmailAddress");
        }
    }
}