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
    class SearchCodePage : TagCodePage
    {
        public SearchCodePage()
        {
            //Tokens 6 and 16 are not supported
            AddToken(0x05, "Search");
            AddToken(0x07, "Store");
            AddToken(0x08, "Name");
            AddToken(0x09, "Query");
            AddToken(0x0A, "Options");
            AddToken(0x0B, "Range");
            AddToken(0x0C, "Status");
            AddToken(0x0D, "Response");
            AddToken(0x0E, "Result");
            AddToken(0x0F, "Properties");
            AddToken(0x10, "Total");
            AddToken(0x11, "EqualTo");
            AddToken(0x12, "Value");
            AddToken(0x13, "And");
            AddToken(0x14, "Or");
            AddToken(0x15, "FreeText");
            AddToken(0x17, "DeepTraversal");
            AddToken(0x18, "LongId");
            AddToken(0x19, "RebuildResults");
            AddToken(0x1A, "LessThan");
            AddToken(0x1B, "GreaterThan");
            AddToken(0x1C, "Schema");
            AddToken(0x1D, "Supported");
            AddToken(0x1E, "UserName");
            AddToken(0x1F, "Password");
            AddToken(0x20, "ConversationId");
        }
    }
}
