using OmaSharp.WBXML;

namespace ActiveSyncDemo
{
    internal class ResolveRecipientsCodePage : TagCodePage
    {
        public ResolveRecipientsCodePage()
        {
            AddToken(0x05, "ResolveRecipients");
            AddToken(0x06, "Response");
            AddToken(0x07, "Status");
            AddToken(0x08, "Type");
            AddToken(0x09, "Recipient");
            AddToken(0x0A, "DisplayName");
            AddToken(0x0B, "EmailAddress");
            AddToken(0x0C, "Certificates");
            AddToken(0x0D, "Certificate");
            AddToken(0x0E, "MiniCertificate");
            AddToken(0x0F, "Options");
            AddToken(0x10, "To");
            AddToken(0x11, "CertificateRetrieval");
            AddToken(0x12, "RecipientCount");
            AddToken(0x13, "MaxCertificates");
            AddToken(0x14, "MaxAmbiguousRecipients");
            AddToken(0x15, "CertificateCount");
        }
    }
}