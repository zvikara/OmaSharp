using WBXML;

namespace WapProvisioning
{
    public class AttributeCodePage1 : AttributeCodePage
    {
        public AttributeCodePage1()
        {
            AddAttributeStart(0x05, "name");
            AddAttributeStart(0x06, "value");
            AddAttributeStart(0x07, "name", "NAME");
            AddAttributeStart(0x14, "name", "INTERNET");
            AddAttributeStart(0x1C, "name", "STARTPAGE");
            AddAttributeStart(0x22, "name", "TO-NAPID");
            AddAttributeStart(0x23, "name", "PORTNBR");
            AddAttributeStart(0x24, "name", "SERVICE");
            AddAttributeStart(0x2E, "name", "AACCEPT");
            AddAttributeStart(0x2F, "name", "AAUTHDATA");
            AddAttributeStart(0x30, "name", "AAUTHLEVEL");
            AddAttributeStart(0x31, "name", "AAUTHNAME");
            AddAttributeStart(0x32, "name", "AAUTHSECRET");
            AddAttributeStart(0x33, "name", "AAUTHTYPE");
            AddAttributeStart(0x34, "name", "ADDR");
            AddAttributeStart(0x35, "name", "ADDRTYPE");
            AddAttributeStart(0x36, "name", "APPID");
            AddAttributeStart(0x37, "name", "APROTOCOL");
            AddAttributeStart(0x38, "name", "PROVIDER-ID");
            AddAttributeStart(0x39, "name", "TO-PROXY");
            AddAttributeStart(0x3A, "name", "URI");
            AddAttributeStart(0x3B, "name", "RULE");

            AddAttributeStart(0x50, "type");
            AddAttributeStart(0x53, "type", "PORT");
            AddAttributeStart(0x55, "type", "APPLICATION");
            AddAttributeStart(0x56, "type", "APPADDR");
            AddAttributeStart(0x57, "type", "APPAUTH");
            AddAttributeStart(0x58, "type", "CLIENTIDENTITY");
            AddAttributeStart(0x59, "type", "RESOURCE");

            // 7.3.1 ADDRTYPE Value
            AddAttributeValue(0x86, "IPV6");
            AddAttributeValue(0x87, "E164");
            AddAttributeValue(0x88, "ALPHA");
            AddAttributeValue(0x8D, "APPSRV");
            AddAttributeValue(0x8E, "OBEX");

            // 7.3.3 AUTHTYPE/PXAUTH-TYPE Value
            AddAttributeValue(0x9A, "PAP");
            AddAttributeValue(0x9B, "CHAP");
            AddAttributeValue(0x9C, "HTTP-BASIC");
            AddAttributeValue(0x9D, "HTTP-DIGEST");
            AddAttributeValue(0x9E, "WTLS-SS");
            AddAttributeValue(0x9F, "MD5");

            // 7.3.4 BEARER Value
            AddAttributeValue(0xA2, "GSM-USSD");
            AddAttributeValue(0xA3, "GSM-SMS");
            AddAttributeValue(0xA4, "ANSI-136-GUTS");
            AddAttributeValue(0xA5, "IS-95-CDMA-SMS");
            AddAttributeValue(0xA6, "IS-95-CDMA-CSD");
            AddAttributeValue(0xA7, "IS-95-CDMA-PACKET");
            AddAttributeValue(0xA8, "ANSI-136-CSD");
            AddAttributeValue(0xA9, "ANSI-136-GPRS");
            AddAttributeValue(0xAA, "GSM-CSD");
            AddAttributeValue(0xAB, "GSM-GPRS");
            AddAttributeValue(0xAC, "AMPS-CDPD");
            AddAttributeValue(0xAD, "PDC-CSD");
            AddAttributeValue(0xAE, "PDC-PACKET");
            AddAttributeValue(0xAF, "IDEN-SMS");
            AddAttributeValue(0xB0, "IDEN-CSD");
            AddAttributeValue(0xB1, "IDEN-PACKET");
            AddAttributeValue(0xB2, "FLEX/REFLEX");
            AddAttributeValue(0xB3, "PHS-SMS");
            AddAttributeValue(0xB4, "PHS-CSD");
            AddAttributeValue(0xB5, "TETRA-SDS");
            AddAttributeValue(0xB6, "TETRA-PACKET");
            AddAttributeValue(0xB7, "ANSI-136-GHOST");
            AddAttributeValue(0xB8, "MOBITEX-MPAK");
            AddAttributeValue(0xB9, "CDMA2000-1X-SIMPLE-IP");
            AddAttributeValue(0xBA, "CDMA2000-1X-MOBILE-IP");

            // 7.3.5 LINKSPEED Value
            AddAttributeValue(0xC5, "AUTOBAUDING");

            // 7.3.6 SERVICE Value
            AddAttributeValue(0xCA, "CL-WSP");
            AddAttributeValue(0xCB, "CO-WSP");
            AddAttributeValue(0xCC, "CL-SEC-WSP");
            AddAttributeValue(0xCD, "CO-SEC-WSP");
            AddAttributeValue(0xCE, "CL-SEC-WTA");
            AddAttributeValue(0xCF, "CO-SEC-WTA");
            AddAttributeValue(0xD0, "OTA-HTTP-TO");
            AddAttributeValue(0xD1, "OTA-HTTP-TLS-TO");
            AddAttributeValue(0xD2, "OTA-HTTP-PO");
            AddAttributeValue(0xD3, "OTA-HTTP-TLS-PO");

            // 7.3.7 AAUTHTYPE Value
            AddAttributeValue(0x90, ",");
            AddAttributeValue(0x91, "HTTP-");
            AddAttributeValue(0x92, "BASIC");
            AddAttributeValue(0x93, "DIGEST");
        }
    }
}
