using WBXML;

namespace ActiveSyncDemo
{
    internal class SettingsCodePage : TagCodePage
    {
        public SettingsCodePage()
        {
            AddToken(0x05, "Settings");
            AddToken(0x06, "Status");
            AddToken(0x07, "Get");
            AddToken(0x08, "Set");
            AddToken(0x09, "Oof");
            AddToken(0x0A, "OofState");
            AddToken(0x0B, "StartTime");
            AddToken(0x0C, "EndTime");
            AddToken(0x0D, "OofMessage");
            AddToken(0x0E, "AppliesToInternal");
            AddToken(0x0F, "AppliesToExternalKnown");
            AddToken(0x10, "AppliesToExternalUnknown");
            AddToken(0x11, "Enabled");
            AddToken(0x12, "ReplyMessage");
            AddToken(0x13, "BodyType");
            AddToken(0x14, "DevicePassword");
            AddToken(0x15, "Password");
            AddToken(0x16, "DeviceInformaton");
            AddToken(0x17, "Model");
            AddToken(0x18, "IMEI");
            AddToken(0x19, "FriendlyName");
            AddToken(0x1A, "OS");
            AddToken(0x1B, "OSLanguage");
            AddToken(0x1C, "PhoneNumber");
            AddToken(0x1D, "UserInformation");
            AddToken(0x1E, "EmailAddresses");
            AddToken(0x1F, "SmtpAddress");
            AddToken(0x20, "UserAgent");
            AddToken(0x21, "EnableOutboundSMS");
            AddToken(0x22, "MobileOperator");
        }
    }
}