// Copyright 2012 - Johan de Koning (johan@johandekoning.nl)
// 
// This file is part of WBXML .Net Library.
// Permission is hereby granted, free of charge, to any person obtaining a copy 
// of this software and associated documentation files (the "Software"), to deal in 
// the Software without restriction, including without limitation the rights to use, 
// copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the 
// Software, and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies 
// or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE 
// USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// The WAP Binary XML (WBXML) specification is developed by the 
// Open Mobile Alliance (http://www.openmobilealliance.org/)
// Details about this specification can be found at
// http://www.openmobilealliance.org/tech/affiliates/wap/wap-192-wbxml-20010725-a.pdf

using WBXML;

namespace SyncMLDemo
{
    public class SyncMLCodeSpace : TagCodeSpace
    {
        public SyncMLCodeSpace()
        {
            var zeroPage = new TagCodePage();
            zeroPage.AddToken(0x05, "Add");
            zeroPage.AddToken(0x06, "Alert");
            zeroPage.AddToken(0x07, "Archive");
            zeroPage.AddToken(0x08, "Atomic");
            zeroPage.AddToken(0x09, "Chal");
            zeroPage.AddToken(0x0A, "Cmd");
            zeroPage.AddToken(0x0B, "CmdID");
            zeroPage.AddToken(0x0C, "CmdRef");
            zeroPage.AddToken(0x0D, "Copy");
            zeroPage.AddToken(0x0E, "Cred");
            zeroPage.AddToken(0x0F, "Data");
            zeroPage.AddToken(0x10, "Delete");
            zeroPage.AddToken(0x11, "Exec");
            zeroPage.AddToken(0x12, "Final");
            zeroPage.AddToken(0x13, "Get");
            zeroPage.AddToken(0x14, "Item");
            zeroPage.AddToken(0x15, "Lang");
            zeroPage.AddToken(0x16, "LocName");
            zeroPage.AddToken(0x17, "LocURI");
            zeroPage.AddToken(0x18, "Map");
            zeroPage.AddToken(0x19, "MapItem");
            zeroPage.AddToken(0x1A, "Meta");
            zeroPage.AddToken(0x1B, "MsgID");
            zeroPage.AddToken(0x1C, "MsgRef");
            zeroPage.AddToken(0x1D, "NoResp");
            zeroPage.AddToken(0x1E, "NoResults");
            zeroPage.AddToken(0x1F, "Put");
            zeroPage.AddToken(0x20, "Replace");
            zeroPage.AddToken(0x21, "RespURI");
            zeroPage.AddToken(0x22, "Results");
            zeroPage.AddToken(0x23, "Search");
            zeroPage.AddToken(0x24, "Sequence");
            zeroPage.AddToken(0x25, "SessionID");
            zeroPage.AddToken(0x26, "SftDel");
            zeroPage.AddToken(0x27, "Source");
            zeroPage.AddToken(0x28, "SourceRef");
            zeroPage.AddToken(0x29, "Status");
            zeroPage.AddToken(0x2A, "Sync");
            zeroPage.AddToken(0x2B, "SyncBody");
            zeroPage.AddToken(0x2C, "SyncHdr");
            zeroPage.AddToken(0x2D, "SyncML");
            zeroPage.AddToken(0x2E, "Target");
            zeroPage.AddToken(0x2F, "TargetRef");
            zeroPage.AddToken(0x31, "VerDTD");
            zeroPage.AddToken(0x32, "VerProto");
            zeroPage.AddToken(0x33, "NumberOfChanges");
            zeroPage.AddToken(0x34, "MoreData");

            var onePage = new TagCodePage();
            onePage.AddToken(0x05, "Anchor");
            onePage.AddToken(0x06, "EMI");
            onePage.AddToken(0x07, "Format");
            onePage.AddToken(0x08, "FreeID");
            onePage.AddToken(0x09, "FreeMem");
            onePage.AddToken(0x0A, "Last");
            onePage.AddToken(0x0B, "Mark");
            onePage.AddToken(0x0C, "MaxMsgSize");
            onePage.AddToken(0x15, "MaxObjSize");
            onePage.AddToken(0x0D, "Mem");
            onePage.AddToken(0x0E, "MetInf");
            onePage.AddToken(0x0F, "Next");
            onePage.AddToken(0x10, "NextOnce");
            onePage.AddToken(0x11, "SharedMem");
            onePage.AddToken(0x12, "Size");
            onePage.AddToken(0x13, "Type");
            onePage.AddToken(0x14, "Version");

            AddCodePage(zeroPage);
            AddCodePage(onePage);
        }

        public override int GetPublicIdentifier()
        {
            return 0xfd3;
        }
    }
}