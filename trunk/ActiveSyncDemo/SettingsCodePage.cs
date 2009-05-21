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
    class SettingsCodePage : TagCodePage
    {
        public SettingsCodePage()
        {
            AddToken(0x05, "Settings");
            AddToken(0x06, "Status");
            AddToken(0x07, "Get");
            AddToken(0x08, "Set");
            AddToken(0x09, "Oof");
            AddToken(0x0A, "OofState");
            AddToken(0x0B, "StartTime");
            AddToken(0x0C, "EndTime");
            AddToken(0x0D, "OofMessage");
            AddToken(0x0E, "AppliesToInternal");
            AddToken(0x0F, "AppliesToExternalKnown");
            AddToken(0x10, "AppliesToExternalUnknown");
            AddToken(0x11, "Enabled");
            AddToken(0x12, "ReplyMessage");
            AddToken(0x13, "BodyType");
            AddToken(0x14, "DevicePassword");
            AddToken(0x15, "Password");
            AddToken(0x16, "DeviceInformaton");
            AddToken(0x17, "Model");
            AddToken(0x18, "IMEI");
            AddToken(0x19, "FriendlyName");
            AddToken(0x1A, "OS");
            AddToken(0x1B, "OSLanguage");
            AddToken(0x1C, "PhoneNumber");
            AddToken(0x1D, "UserInformation");
            AddToken(0x1E, "EmailAddresses");
            AddToken(0x1F, "SmtpAddress");
            AddToken(0x20, "UserAgent");
            AddToken(0x21, "EnableOutboundSMS");
            AddToken(0x22, "MobileOperator");
        }
    }
}
