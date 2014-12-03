using WBXML;

namespace ActiveSyncDemo
{
    internal class ValidateCertCodePage : TagCodePage
    {
        public ValidateCertCodePage()
        {
            AddToken(0x05, "ValidateCert");
            AddToken(0x06, "Certificates");
            AddToken(0x07, "Certificate");
            AddToken(0x08, "CertificateChain");
            AddToken(0x09, "CheckCRL");
            AddToken(0x0A, "Status");
        }
    }
}