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
    class ComposeMailCodePage : TagCodePage
    {
        public ComposeMailCodePage()
        {
            AddToken(0x05, "SendMail");
            AddToken(0x06, "SmartForward");
            AddToken(0x07, "SmartReply");
            AddToken(0x08, "SaveInSentItems");
            AddToken(0x09, "ReplaceMime");
            AddToken(0x0A, "Type");
            AddToken(0x0B, "Source");
            AddToken(0x0C, "FolderId");
            AddToken(0x0D, "ItemId");
            AddToken(0x0E, "LongId");
            AddToken(0x0F, "InstanceId");
            AddToken(0x10, "Mime");
            AddToken(0x11, "ClientId");
            AddToken(0x12, "Status");
        }
    }
}
