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
    class ItemOperationsCodePage : TagCodePage
    {
        public ItemOperationsCodePage()
        {
            AddToken(0x05, "ItemOperations");
            AddToken(0x06, "Fetch");
            AddToken(0x07, "Store");
            AddToken(0x08, "Options");
            AddToken(0x09, "Range");
            AddToken(0x0A, "Total");
            AddToken(0x0B, "Properties");
            AddToken(0x0C, "Data");
            AddToken(0x0D, "Status");
            AddToken(0x0E, "Response");
            AddToken(0x0F, "Version");
            AddToken(0x10, "Schema");
            AddToken(0x11, "Part");
            AddToken(0x12, "EmptyFolderContents");
            AddToken(0x13, "DeleteSubFolders");
            AddToken(0x14, "UserName");
            AddToken(0x15, "Password");
            AddToken(0x16, "Move");
            AddToken(0x17, "DstFldId");
            AddToken(0x18, "ConversationId");
            AddToken(0x19, "MoveAlways");
        }
    }
}
