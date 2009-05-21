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
    public class ActiveSyncCodeSpace : TagCodeSpace
    {
        public ActiveSyncCodeSpace()
        {
            AddCodePage(new AirSyncCodePage());
            AddCodePage(new ContactsCodePage());
            AddCodePage(new EmailCodePage());
            AddCodePage(new AirNotifyCodePage());
            AddCodePage(new CalendarCodePage());
            AddCodePage(new MoveCodePage());
            AddCodePage(new ItemEstimateCodePage());
            AddCodePage(new FolderHierarchyCodePage());
            AddCodePage(new MeetingResponseCodePage());
            AddCodePage(new TasksCodePage());
            AddCodePage(new ResolveRecipientsCodePage());
            AddCodePage(new ValidateCertCodePage());
            AddCodePage(new Contacts2CodePage());
            AddCodePage(new PingCodePage());
            AddCodePage(new ProvisionCodePage());
            AddCodePage(new SearchCodePage());
            AddCodePage(new GALCodePage());
            AddCodePage(new AirSyncBaseCodePage());
            AddCodePage(new SettingsCodePage());
            AddCodePage(new DocumentLibraryCodePage());
            AddCodePage(new ItemOperationsCodePage());
            AddCodePage(new ComposeMailCodePage());
            AddCodePage(new Email2CodePage());
            AddCodePage(new NotesCodePage());
        }

        public override int GetPublicIdentifier()
        {
            return (int)0x01;
        }
    }
}
