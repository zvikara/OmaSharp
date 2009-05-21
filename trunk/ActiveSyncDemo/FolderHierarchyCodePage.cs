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
    class FolderHierarchyCodePage: TagCodePage
    {
        public FolderHierarchyCodePage()
        {
            AddToken(0x05, "Folders");
            AddToken(0x06, "Folder");
            AddToken(0x07, "DisplayName");
            AddToken(0x08, "ServerId");
            AddToken(0x09, "ParentId");
            AddToken(0x0A, "Type");
            AddToken(0x0B, "Response");
            AddToken(0x0C, "Status");
            AddToken(0x0D, "ContentClass");
            AddToken(0x0E, "Changes");
            AddToken(0x0F, "Add");
            AddToken(0x10, "Delete");
            AddToken(0x11, "Update");
            AddToken(0x12, "SyncKey");
            AddToken(0x13, "FolderCreate");
            AddToken(0x14, "FolderDelete");
            AddToken(0x15, "FolderUpdate");
            AddToken(0x16, "FolderSync");
            AddToken(0x17, "Count");
            AddToken(0x18, "Version");
        }
    }
}
