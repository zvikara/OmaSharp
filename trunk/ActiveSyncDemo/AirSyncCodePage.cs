// Copyright 2009 - Johan de Koning (johan@johandekoning.nl)
// 
// This file is part of WBXML .Net Library.
// The WBXML .Net Library is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// The WBXML .Net Library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
