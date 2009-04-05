using System;
using System.Collections.Generic;
using System.Text;
using WBXML;

namespace SyncMLDemo
{
    public class DevInfCodeSpace : TagCodeSpace
    {
        public DevInfCodeSpace()
        {
            TagCodePage zeroPage = new TagCodePage();
            zeroPage.AddToken(0x05, "CTCap");
            zeroPage.AddToken(0x06, "CTType");
            zeroPage.AddToken(0x07, "DataStore");
            zeroPage.AddToken(0x08, "DataType");
            zeroPage.AddToken(0x09, "DevID");
            zeroPage.AddToken(0x0A, "DevInf");
            zeroPage.AddToken(0x0B, "DevTyp");
            zeroPage.AddToken(0x0C, "DisplayName");
            zeroPage.AddToken(0x0D, "DSMem");
            zeroPage.AddToken(0x0E, "Ext");
            zeroPage.AddToken(0x0F, "FwV");
            zeroPage.AddToken(0x10, "HwV");
            zeroPage.AddToken(0x11, "Man");
            zeroPage.AddToken(0x12, "MaxGUIDSize");
            zeroPage.AddToken(0x13, "MaxID");
            zeroPage.AddToken(0x14, "MaxMem");
            zeroPage.AddToken(0x15, "Mod");
            zeroPage.AddToken(0x16, "OEM");
            zeroPage.AddToken(0x17, "ParamName");
            zeroPage.AddToken(0x18, "PropName");
            zeroPage.AddToken(0x19, "Rx");
            zeroPage.AddToken(0x1A, "Rx-Pref");
            zeroPage.AddToken(0x1B, "SharedMem");
            zeroPage.AddToken(0x1C, "Size");
            zeroPage.AddToken(0x1D, "SourceRef");
            zeroPage.AddToken(0x1E, "SwV");
            zeroPage.AddToken(0x1F, "SyncCap");
            zeroPage.AddToken(0x20, "SyncType");
            zeroPage.AddToken(0x21, "Tx");
            zeroPage.AddToken(0x22, "Tx-Pref");
            zeroPage.AddToken(0x23, "ValEnum");
            zeroPage.AddToken(0x24, "VerCT");
            zeroPage.AddToken(0x25, "VerDTD");
            zeroPage.AddToken(0x26, "Xnam");
            zeroPage.AddToken(0x27, "Xval");
            zeroPage.AddToken(0x28, "UTC");
            zeroPage.AddToken(0x29, "SupportNumberOfChanges");
            zeroPage.AddToken(0x2A, "SupportLargeObjs");

            AddCodePage(zeroPage);
        }

        public override int GetPublicIdentifier()
        {
            return (int)0xfd2;
        }
    }
}
