using WBXML;

namespace WapProvisioning
{
    public class AttributeCodePage0 : AttributeCodePage
    {
        public AttributeCodePage0()
        {
            AddAttributeStart(0x05, "name");
            AddAttributeStart(0x06, "value");
            AddAttributeStart(0x07, "name", "NAME");
            AddAttributeStart(0x08, "name", "NAP-ADDRESS");
            AddAttributeStart(0x09, "name", "NAP-ADDRTYPE");
            AddAttributeStart(0x0A, "name", "CALLTYPE");
            AddAttributeStart(0x0B, "name", "VALIDUNTIL");
            AddAttributeStart(0x0C, "name", "AUTHTYPE");
            AddAttributeStart(0x0D, "name", "AUTHNAME");
            AddAttributeStart(0x0E, "name", "AUTHSECRET");
            AddAttributeStart(0x0F, "name", "LINGER");
            AddAttributeStart(0x10, "name", "BEARER");
            AddAttributeStart(0x11, "name", "NAPID");
            AddAttributeStart(0x12, "name", "COUNTRY");
            AddAttributeStart(0x13, "name", "NETWORK");
            AddAttributeStart(0x14, "name", "INTERNET");
            AddAttributeStart(0x15, "name", "PROXY-ID");
            AddAttributeStart(0x16, "name", "PROXY-PROVIDER-ID");
            AddAttributeStart(0x17, "name", "DOMAIN");
            AddAttributeStart(0x18, "name", "PROVURL");
            AddAttributeStart(0x19, "name", "PXAUTH-TYPE");
            AddAttributeStart(0x1A, "name", "PXAUTH-ID");
            AddAttributeStart(0x1B, "name", "PXAUTH-PW");
            AddAttributeStart(0x1C, "name", "STARTPAGE");
            AddAttributeStart(0x1D, "name", "BASAUTH-ID");
            AddAttributeStart(0x1E, "name", "BASAUTH-PW");
            AddAttributeStart(0x1F, "name", "PUSHENABLED");
            AddAttributeStart(0x20, "name", "PXADDR");
            AddAttributeStart(0x21, "name", "PXADDRTYPE");
            AddAttributeStart(0x22, "name", "TO-NAPID");
            AddAttributeStart(0x23, "name", "PORTNBR");
            AddAttributeStart(0x24, "name", "SERVICE");
            AddAttributeStart(0x25, "name", "LINKSPEED");
            AddAttributeStart(0x26, "name", "DNLINKSPEED");
            AddAttributeStart(0x27, "name", "LOCAL-ADDR");
            AddAttributeStart(0x28, "name", "LOCAL-ADDRTYPE");
            AddAttributeStart(0x29, "name", "CONTEXT-ALLOW");
            AddAttributeStart(0x2A, "name", "TRUST");
            AddAttributeStart(0x2B, "name", "MASTER");
            AddAttributeStart(0x2C, "name", "SID");
            AddAttributeStart(0x2D, "name", "SOC");
            AddAttributeStart(0x2E, "name", "WSP-VERSION");
            AddAttributeStart(0x2F, "name", "PHYSICAL-PROXY-ID");
            AddAttributeStart(0x30, "name", "CLIENT-ID");
            AddAttributeStart(0x31, "name", "DELIVERY-ERR-SDU");
            AddAttributeStart(0x32, "name", "DELIVERY-ORDER");
            AddAttributeStart(0x33, "name", "TRAFFIC-CLASS");
            AddAttributeStart(0x34, "name", "MAX-SDU-SIZE");
            AddAttributeStart(0x35, "name", "MAX-BITRATE-UPLINK");
            AddAttributeStart(0x36, "name", "MAX-BITRATE-DNLINK");
            AddAttributeStart(0x37, "name", "RESIDUAL-BER");
            AddAttributeStart(0x38, "name", "SDU-ERROR-RATIO");
            AddAttributeStart(0x39, "name", "TRAFFIC-HANDL-PRIO");
            AddAttributeStart(0x3A, "name", "TRANSFER-DELAY");
            AddAttributeStart(0x3B, "name", "GUARANTEED-BITRATE-UPLINK");
            AddAttributeStart(0x3C, "name", "GUARANTEED-BITRATE-DNLINK");
            AddAttributeStart(0x3D, "name", "PXADDR-FQDN");
            AddAttributeStart(0x3E, "name", "PROXY-PW");
            AddAttributeStart(0x3F, "name", "PPGAUTH-TYPE");
            AddAttributeStart(0x47, "name", "PULLENABLED");
            AddAttributeStart(0x48, "name", "DNS-ADDR");
            AddAttributeStart(0x49, "name", "MAX-NUM-RETRY");
            AddAttributeStart(0x4A, "name", "FIRST-RETRY-TIMEOUT");
            AddAttributeStart(0x4B, "name", "REREG-THRESHOLD");
            AddAttributeStart(0x4C, "name", "T-BIT");
            AddAttributeStart(0x4E, "name", "AUTH-ENTITY");
            AddAttributeStart(0x4F, "name", "SPI");

            AddAttributeStart(0x45, "version");
            AddAttributeStart(0x46, "version", "1.0");
            AddAttributeStart(0x50, "type");
            AddAttributeStart(0x51, "type", "PXLOGICAL");
            AddAttributeStart(0x52, "type", "PXPHYSICAL");
            AddAttributeStart(0x53, "type", "PORT");
            AddAttributeStart(0x54, "type", "VALIDITY");
            AddAttributeStart(0x55, "type", "NAPDEF");
            AddAttributeStart(0x56, "type", "BOOTSTRAP");
            AddAttributeStart(0x57, "type", "VENDORCONFIG");
            AddAttributeStart(0x58, "type", "CLIENTIDENTITY");
            AddAttributeStart(0x59, "type", "PXAUTHINFO");
            AddAttributeStart(0x5A, "type", "NAPAUTHINFO");
            AddAttributeStart(0x5B, "type", "ACCESS");

            // 7.3.1 ADDRTYPE Value
            AddAttributeValue(0x85, "IPV4");
            AddAttributeValue(0x86, "IPV6");
            AddAttributeValue(0x87, "E164");
            AddAttributeValue(0x88, "ALPHA");
            AddAttributeValue(0x89, "APN");
            AddAttributeValue(0x8A, "SCODE");
            AddAttributeValue(0x8B, "TETRA-ITSI");
            AddAttributeValue(0x8C, "MAN");

            // 7.3.2 CALLTYPE Value
            AddAttributeValue(0x90, "ANALOG-MODEM");
            AddAttributeValue(0x91, "V.120");
            AddAttributeValue(0x92, "V.110");
            AddAttributeValue(0x93, "X.31");
            AddAttributeValue(0x94, "BIT-TRANSPARENT");
            AddAttributeValue(0x95, "DIRECT-ASYNCHRONOUS-DATA-SERVICE");

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

            // 7.3.8 AUTH-ENTITY Value
            AddAttributeValue(0xE0, "AAA");
            AddAttributeValue(0xE1, "HA");
        }
    }
}
