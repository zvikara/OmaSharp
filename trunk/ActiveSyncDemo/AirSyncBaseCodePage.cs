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
    class AirSyncBaseCodePage : TagCodePage
    {
        public AirSyncBaseCodePage()
        {
            AddToken(0x05, "BodyPreference");
            AddToken(0x06, "Type");
            AddToken(0x07, "TruncationSize");
            AddToken(0x08, "AllOrNone");
            AddToken(0x0A, "Body");
            AddToken(0x0B, "Data");
            AddToken(0x0C, "EstimatedDataSize");
            AddToken(0x0D, "Truncated");
            AddToken(0x0E, "Attachments");
            AddToken(0x0F, "Attachment");
            AddToken(0x10, "DisplayName");
            AddToken(0x11, "FileReference");
            AddToken(0x12, "Method");
            AddToken(0x13, "ContentId");
            AddToken(0x14, "ContentLocation");
            AddToken(0x15, "IsInline");
            AddToken(0x16, "NativeBodyType");
            AddToken(0x17, "ContentType");
            AddToken(0x18, "Preview");
        }
    }
}
