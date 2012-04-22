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
//
// The ActiveSync WAP Binary XML (MS-ASWBXML) specification is 
// developed by Microsoft (http://www.microsoft.com/)
// Details about this specification can be found at 
// http://msdn.microsoft.com/en-us/library/dd299442.aspx

using WBXML;

namespace ActiveSyncDemo
{
    public class AirSyncCodePage : TagCodePage
    {
        public AirSyncCodePage()
        {
            AddToken(0x05, "Sync");
            AddToken(0x06, "Responses");
            AddToken(0x07, "Add");
            AddToken(0x08, "Change");
            AddToken(0x09, "Delete");
            AddToken(0x0A, "Fetch");
            AddToken(0x0B, "SyncKey");
            AddToken(0x0C, "ClientId");
            AddToken(0x0D, "ServerId");
            AddToken(0x0E, "Status");
            AddToken(0x0F, "Collection");
            AddToken(0x10, "Class");
            AddToken(0x11, "Version");
            AddToken(0x12, "CollectionId");
            AddToken(0x13, "GetChanges");
            AddToken(0x14, "MoreAvailable");
            AddToken(0x15, "WindowSize");
            AddToken(0x16, "Commands");
            AddToken(0x17, "Options");
            AddToken(0x18, "FilterType");
            AddToken(0x19, "Truncation");
            AddToken(0x1A, "RTFTrunction");
            AddToken(0x1B, "Conflict");
            AddToken(0x1C, "Collections");
            AddToken(0x1D, "ApplicationData");
            AddToken(0x1E, "DeletesAsMoves");
            AddToken(0x1F, "NotifyGUID");
            AddToken(0x20, "Supported");
            AddToken(0x21, "SoftDelete");
            AddToken(0x22, "MIMESupport");
            AddToken(0x23, "MIMETruncation");
            AddToken(0x24, "Wait");
            AddToken(0x25, "Limit");
            AddToken(0x26, "Partial");
            AddToken(0x27, "ConversationMode");
            AddToken(0x28, "MaxItems");
            AddToken(0x29, "HeartbeatInterval");
        }
    }
}