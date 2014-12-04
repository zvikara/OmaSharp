namespace WBXML.Tests.WapProvisioning
{
    public class AttributeCodeSpace : WBXML.AttributeCodeSpace
    {
        public AttributeCodeSpace()
        {
            AddCodePage(GetCodePage0());
            AddCodePage(GetCodePage1());
        }

        private static AttributeCodePage GetCodePage0()
        {
            var codePage = new AttributeCodePage();
            codePage.AddAttributeStart(0x05, "name");
            codePage.AddAttributeStart(0x06, "value");
            codePage.AddAttributeStart(0x07, "name", "NAME");
            codePage.AddAttributeStart(0x08, "name", "NAP-ADDRESS");
            codePage.AddAttributeStart(0x09, "name", "NAP-ADDRTYPE");
            codePage.AddAttributeStart(0x0A, "name", "CALLTYPE");
            codePage.AddAttributeStart(0x0B, "name", "VALIDUNTIL");
            codePage.AddAttributeStart(0x0C, "name", "AUTHTYPE");
            codePage.AddAttributeStart(0x0D, "name", "AUTHNAME");
            codePage.AddAttributeStart(0x0E, "name", "AUTHSECRET");
            codePage.AddAttributeStart(0x0F, "name", "LINGER");
            codePage.AddAttributeStart(0x10, "name", "BEARER");
            codePage.AddAttributeStart(0x11, "name", "NAPID");
            codePage.AddAttributeStart(0x12, "name", "COUNTRY");
            codePage.AddAttributeStart(0x13, "name", "NETWORK");
            codePage.AddAttributeStart(0x14, "name", "INTERNET");
            codePage.AddAttributeStart(0x15, "name", "PROXY-ID");
            codePage.AddAttributeStart(0x16, "name", "PROXY-PROVIDER-ID");
            codePage.AddAttributeStart(0x17, "name", "DOMAIN");
            codePage.AddAttributeStart(0x18, "name", "PROVURL");
            codePage.AddAttributeStart(0x19, "name", "PXAUTH-TYPE");
            codePage.AddAttributeStart(0x1A, "name", "PXAUTH-ID");
            codePage.AddAttributeStart(0x1B, "name", "PXAUTH-PW");
            codePage.AddAttributeStart(0x1C, "name", "STARTPAGE");
            codePage.AddAttributeStart(0x1D, "name", "BASAUTH-ID");
            codePage.AddAttributeStart(0x1E, "name", "BASAUTH-PW");
            codePage.AddAttributeStart(0x1F, "name", "PUSHENABLED");
            codePage.AddAttributeStart(0x20, "name", "PXADDR");
            codePage.AddAttributeStart(0x21, "name", "PXADDRTYPE");
            codePage.AddAttributeStart(0x22, "name", "TO-NAPID");
            codePage.AddAttributeStart(0x23, "name", "PORTNBR");
            codePage.AddAttributeStart(0x24, "name", "SERVICE");
            codePage.AddAttributeStart(0x25, "name", "LINKSPEED");
            codePage.AddAttributeStart(0x26, "name", "DNLINKSPEED");
            codePage.AddAttributeStart(0x27, "name", "LOCAL-ADDR");
            codePage.AddAttributeStart(0x28, "name", "LOCAL-ADDRTYPE");
            codePage.AddAttributeStart(0x29, "name", "CONTEXT-ALLOW");
            codePage.AddAttributeStart(0x2A, "name", "TRUST");
            codePage.AddAttributeStart(0x2B, "name", "MASTER");
            codePage.AddAttributeStart(0x2C, "name", "SID");
            codePage.AddAttributeStart(0x2D, "name", "SOC");
            codePage.AddAttributeStart(0x2E, "name", "WSP-VERSION");
            codePage.AddAttributeStart(0x2F, "name", "PHYSICAL-PROXY-ID");
            codePage.AddAttributeStart(0x30, "name", "CLIENT-ID");
            codePage.AddAttributeStart(0x31, "name", "DELIVERY-ERR-SDU");
            codePage.AddAttributeStart(0x32, "name", "DELIVERY-ORDER");
            codePage.AddAttributeStart(0x33, "name", "TRAFFIC-CLASS");
            codePage.AddAttributeStart(0x34, "name", "MAX-SDU-SIZE");
            codePage.AddAttributeStart(0x35, "name", "MAX-BITRATE-UPLINK");
            codePage.AddAttributeStart(0x36, "name", "MAX-BITRATE-DNLINK");
            codePage.AddAttributeStart(0x37, "name", "RESIDUAL-BER");
            codePage.AddAttributeStart(0x38, "name", "SDU-ERROR-RATIO");
            codePage.AddAttributeStart(0x39, "name", "TRAFFIC-HANDL-PRIO");
            codePage.AddAttributeStart(0x3A, "name", "TRANSFER-DELAY");
            codePage.AddAttributeStart(0x3B, "name", "GUARANTEED-BITRATE-UPLINK");
            codePage.AddAttributeStart(0x3C, "name", "GUARANTEED-BITRATE-DNLINK");
            codePage.AddAttributeStart(0x3D, "name", "PXADDR-FQDN");
            codePage.AddAttributeStart(0x3E, "name", "PROXY-PW");
            codePage.AddAttributeStart(0x3F, "name", "PPGAUTH-TYPE");
            codePage.AddAttributeStart(0x47, "name", "PULLENABLED");
            codePage.AddAttributeStart(0x48, "name", "DNS-ADDR");
            codePage.AddAttributeStart(0x49, "name", "MAX-NUM-RETRY");
            codePage.AddAttributeStart(0x4A, "name", "FIRST-RETRY-TIMEOUT");
            codePage.AddAttributeStart(0x4B, "name", "REREG-THRESHOLD");
            codePage.AddAttributeStart(0x4C, "name", "T-BIT");
            codePage.AddAttributeStart(0x4E, "name", "AUTH-ENTITY");
            codePage.AddAttributeStart(0x4F, "name", "SPI");

            codePage.AddAttributeStart(0x45, "version");
            codePage.AddAttributeStart(0x46, "version", "1.0");
            codePage.AddAttributeStart(0x50, "type");
            codePage.AddAttributeStart(0x51, "type", "PXLOGICAL");
            codePage.AddAttributeStart(0x52, "type", "PXPHYSICAL");
            codePage.AddAttributeStart(0x53, "type", "PORT");
            codePage.AddAttributeStart(0x54, "type", "VALIDITY");
            codePage.AddAttributeStart(0x55, "type", "NAPDEF");
            codePage.AddAttributeStart(0x56, "type", "BOOTSTRAP");
            codePage.AddAttributeStart(0x57, "type", "VENDORCONFIG");
            codePage.AddAttributeStart(0x58, "type", "CLIENTIDENTITY");
            codePage.AddAttributeStart(0x59, "type", "PXAUTHINFO");
            codePage.AddAttributeStart(0x5A, "type", "NAPAUTHINFO");
            codePage.AddAttributeStart(0x5B, "type", "ACCESS");

            // 7.3.1 ADDRTYPE Value
            codePage.AddAttributeValue(0x85, "IPV4");
            codePage.AddAttributeValue(0x86, "IPV6");
            codePage.AddAttributeValue(0x87, "E164");
            codePage.AddAttributeValue(0x88, "ALPHA");
            codePage.AddAttributeValue(0x89, "APN");
            codePage.AddAttributeValue(0x8A, "SCODE");
            codePage.AddAttributeValue(0x8B, "TETRA-ITSI");
            codePage.AddAttributeValue(0x8C, "MAN");

            // 7.3.2 CALLTYPE Value
            codePage.AddAttributeValue(0x90, "ANALOG-MODEM");
            codePage.AddAttributeValue(0x91, "V.120");
            codePage.AddAttributeValue(0x92, "V.110");
            codePage.AddAttributeValue(0x93, "X.31");
            codePage.AddAttributeValue(0x94, "BIT-TRANSPARENT");
            codePage.AddAttributeValue(0x95, "DIRECT-ASYNCHRONOUS-DATA-SERVICE");

            // 7.3.3 AUTHTYPE/PXAUTH-TYPE Value
            codePage.AddAttributeValue(0x9A, "PAP");
            codePage.AddAttributeValue(0x9B, "CHAP");
            codePage.AddAttributeValue(0x9C, "HTTP-BASIC");
            codePage.AddAttributeValue(0x9D, "HTTP-DIGEST");
            codePage.AddAttributeValue(0x9E, "WTLS-SS");
            codePage.AddAttributeValue(0x9F, "MD5");

            // 7.3.4 BEARER Value
            codePage.AddAttributeValue(0xA2, "GSM-USSD");
            codePage.AddAttributeValue(0xA3, "GSM-SMS");
            codePage.AddAttributeValue(0xA4, "ANSI-136-GUTS");
            codePage.AddAttributeValue(0xA5, "IS-95-CDMA-SMS");
            codePage.AddAttributeValue(0xA6, "IS-95-CDMA-CSD");
            codePage.AddAttributeValue(0xA7, "IS-95-CDMA-PACKET");
            codePage.AddAttributeValue(0xA8, "ANSI-136-CSD");
            codePage.AddAttributeValue(0xA9, "ANSI-136-GPRS");
            codePage.AddAttributeValue(0xAA, "GSM-CSD");
            codePage.AddAttributeValue(0xAB, "GSM-GPRS");
            codePage.AddAttributeValue(0xAC, "AMPS-CDPD");
            codePage.AddAttributeValue(0xAD, "PDC-CSD");
            codePage.AddAttributeValue(0xAE, "PDC-PACKET");
            codePage.AddAttributeValue(0xAF, "IDEN-SMS");
            codePage.AddAttributeValue(0xB0, "IDEN-CSD");
            codePage.AddAttributeValue(0xB1, "IDEN-PACKET");
            codePage.AddAttributeValue(0xB2, "FLEX/REFLEX");
            codePage.AddAttributeValue(0xB3, "PHS-SMS");
            codePage.AddAttributeValue(0xB4, "PHS-CSD");
            codePage.AddAttributeValue(0xB5, "TETRA-SDS");
            codePage.AddAttributeValue(0xB6, "TETRA-PACKET");
            codePage.AddAttributeValue(0xB7, "ANSI-136-GHOST");
            codePage.AddAttributeValue(0xB8, "MOBITEX-MPAK");
            codePage.AddAttributeValue(0xB9, "CDMA2000-1X-SIMPLE-IP");
            codePage.AddAttributeValue(0xBA, "CDMA2000-1X-MOBILE-IP");

            // 7.3.5 LINKSPEED Value
            codePage.AddAttributeValue(0xC5, "AUTOBAUDING");

            // 7.3.6 SERVICE Value
            codePage.AddAttributeValue(0xCA, "CL-WSP");
            codePage.AddAttributeValue(0xCB, "CO-WSP");
            codePage.AddAttributeValue(0xCC, "CL-SEC-WSP");
            codePage.AddAttributeValue(0xCD, "CO-SEC-WSP");
            codePage.AddAttributeValue(0xCE, "CL-SEC-WTA");
            codePage.AddAttributeValue(0xCF, "CO-SEC-WTA");
            codePage.AddAttributeValue(0xD0, "OTA-HTTP-TO");
            codePage.AddAttributeValue(0xD1, "OTA-HTTP-TLS-TO");
            codePage.AddAttributeValue(0xD2, "OTA-HTTP-PO");
            codePage.AddAttributeValue(0xD3, "OTA-HTTP-TLS-PO");

            // 7.3.8 AUTH-ENTITY Value
            codePage.AddAttributeValue(0xE0, "AAA");
            codePage.AddAttributeValue(0xE1, "HA");

            return codePage;
        }

        private static AttributeCodePage GetCodePage1()
        {
            var codePage = new AttributeCodePage();
            codePage.AddAttributeStart(0x05, "name");
            codePage.AddAttributeStart(0x06, "value");
            codePage.AddAttributeStart(0x07, "name", "NAME");
            codePage.AddAttributeStart(0x14, "name", "INTERNET");
            codePage.AddAttributeStart(0x1C, "name", "STARTPAGE");
            codePage.AddAttributeStart(0x22, "name", "TO-NAPID");
            codePage.AddAttributeStart(0x23, "name", "PORTNBR");
            codePage.AddAttributeStart(0x24, "name", "SERVICE");
            codePage.AddAttributeStart(0x2E, "name", "AACCEPT");
            codePage.AddAttributeStart(0x2F, "name", "AAUTHDATA");
            codePage.AddAttributeStart(0x30, "name", "AAUTHLEVEL");
            codePage.AddAttributeStart(0x31, "name", "AAUTHNAME");
            codePage.AddAttributeStart(0x32, "name", "AAUTHSECRET");
            codePage.AddAttributeStart(0x33, "name", "AAUTHTYPE");
            codePage.AddAttributeStart(0x34, "name", "ADDR");
            codePage.AddAttributeStart(0x35, "name", "ADDRTYPE");
            codePage.AddAttributeStart(0x36, "name", "APPID");
            codePage.AddAttributeStart(0x37, "name", "APROTOCOL");
            codePage.AddAttributeStart(0x38, "name", "PROVIDER-ID");
            codePage.AddAttributeStart(0x39, "name", "TO-PROXY");
            codePage.AddAttributeStart(0x3A, "name", "URI");
            codePage.AddAttributeStart(0x3B, "name", "RULE");

            codePage.AddAttributeStart(0x50, "type");
            codePage.AddAttributeStart(0x53, "type", "PORT");
            codePage.AddAttributeStart(0x55, "type", "APPLICATION");
            codePage.AddAttributeStart(0x56, "type", "APPADDR");
            codePage.AddAttributeStart(0x57, "type", "APPAUTH");
            codePage.AddAttributeStart(0x58, "type", "CLIENTIDENTITY");
            codePage.AddAttributeStart(0x59, "type", "RESOURCE");

            // 7.3.1 ADDRTYPE Value
            codePage.AddAttributeValue(0x86, "IPV6");
            codePage.AddAttributeValue(0x87, "E164");
            codePage.AddAttributeValue(0x88, "ALPHA");
            codePage.AddAttributeValue(0x8D, "APPSRV");
            codePage.AddAttributeValue(0x8E, "OBEX");

            // 7.3.3 AUTHTYPE/PXAUTH-TYPE Value
            codePage.AddAttributeValue(0x9A, "PAP");
            codePage.AddAttributeValue(0x9B, "CHAP");
            codePage.AddAttributeValue(0x9C, "HTTP-BASIC");
            codePage.AddAttributeValue(0x9D, "HTTP-DIGEST");
            codePage.AddAttributeValue(0x9E, "WTLS-SS");
            codePage.AddAttributeValue(0x9F, "MD5");

            // 7.3.4 BEARER Value
            codePage.AddAttributeValue(0xA2, "GSM-USSD");
            codePage.AddAttributeValue(0xA3, "GSM-SMS");
            codePage.AddAttributeValue(0xA4, "ANSI-136-GUTS");
            codePage.AddAttributeValue(0xA5, "IS-95-CDMA-SMS");
            codePage.AddAttributeValue(0xA6, "IS-95-CDMA-CSD");
            codePage.AddAttributeValue(0xA7, "IS-95-CDMA-PACKET");
            codePage.AddAttributeValue(0xA8, "ANSI-136-CSD");
            codePage.AddAttributeValue(0xA9, "ANSI-136-GPRS");
            codePage.AddAttributeValue(0xAA, "GSM-CSD");
            codePage.AddAttributeValue(0xAB, "GSM-GPRS");
            codePage.AddAttributeValue(0xAC, "AMPS-CDPD");
            codePage.AddAttributeValue(0xAD, "PDC-CSD");
            codePage.AddAttributeValue(0xAE, "PDC-PACKET");
            codePage.AddAttributeValue(0xAF, "IDEN-SMS");
            codePage.AddAttributeValue(0xB0, "IDEN-CSD");
            codePage.AddAttributeValue(0xB1, "IDEN-PACKET");
            codePage.AddAttributeValue(0xB2, "FLEX/REFLEX");
            codePage.AddAttributeValue(0xB3, "PHS-SMS");
            codePage.AddAttributeValue(0xB4, "PHS-CSD");
            codePage.AddAttributeValue(0xB5, "TETRA-SDS");
            codePage.AddAttributeValue(0xB6, "TETRA-PACKET");
            codePage.AddAttributeValue(0xB7, "ANSI-136-GHOST");
            codePage.AddAttributeValue(0xB8, "MOBITEX-MPAK");
            codePage.AddAttributeValue(0xB9, "CDMA2000-1X-SIMPLE-IP");
            codePage.AddAttributeValue(0xBA, "CDMA2000-1X-MOBILE-IP");

            // 7.3.5 LINKSPEED Value
            codePage.AddAttributeValue(0xC5, "AUTOBAUDING");

            // 7.3.6 SERVICE Value
            codePage.AddAttributeValue(0xCA, "CL-WSP");
            codePage.AddAttributeValue(0xCB, "CO-WSP");
            codePage.AddAttributeValue(0xCC, "CL-SEC-WSP");
            codePage.AddAttributeValue(0xCD, "CO-SEC-WSP");
            codePage.AddAttributeValue(0xCE, "CL-SEC-WTA");
            codePage.AddAttributeValue(0xCF, "CO-SEC-WTA");
            codePage.AddAttributeValue(0xD0, "OTA-HTTP-TO");
            codePage.AddAttributeValue(0xD1, "OTA-HTTP-TLS-TO");
            codePage.AddAttributeValue(0xD2, "OTA-HTTP-PO");
            codePage.AddAttributeValue(0xD3, "OTA-HTTP-TLS-PO");

            // 7.3.7 AAUTHTYPE Value
            codePage.AddAttributeValue(0x90, ",");
            codePage.AddAttributeValue(0x91, "HTTP-");
            codePage.AddAttributeValue(0x92, "BASIC");
            codePage.AddAttributeValue(0x93, "DIGEST");

            return codePage;
        }
    }
}