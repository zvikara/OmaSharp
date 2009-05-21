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
    class ResolveRecipientsCodePage : TagCodePage
    {
        public ResolveRecipientsCodePage()
        {
            AddToken(0x05, "ResolveRecipients");
            AddToken(0x06, "Response");
            AddToken(0x07, "Status");
            AddToken(0x08, "Type");
            AddToken(0x09, "Recipient");
            AddToken(0x0A, "DisplayName");
            AddToken(0x0B, "EmailAddress");
            AddToken(0x0C, "Certificates");
            AddToken(0x0D, "Certificate");
            AddToken(0x0E, "MiniCertificate");
            AddToken(0x0F, "Options");
            AddToken(0x10, "To");
            AddToken(0x11, "CertificateRetrieval");
            AddToken(0x12, "RecipientCount");
            AddToken(0x13, "MaxCertificates");
            AddToken(0x14, "MaxAmbiguousRecipients");
            AddToken(0x15, "CertificateCount");
        }
    }
}
