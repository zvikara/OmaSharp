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
    public class EmailCodePage : TagCodePage
    {
        public EmailCodePage()
        {
            AddToken(0x05, "Attachment");
            AddToken(0x06, "Attachments");
            AddToken(0x07, "AttName");
            AddToken(0x08, "AttSize");
            AddToken(0x09, "Att0Id");
            AddToken(0x0A, "AttMethod");
            AddToken(0x0B, "AttRemoved");
            AddToken(0x0C, "Body");
            AddToken(0x0D, "BodySize");
            AddToken(0x0E, "BodyTruncated");
            AddToken(0x0F, "DateReceived");
            AddToken(0x10, "DisplayName");
            AddToken(0x11, "DisplayTo");
            AddToken(0x12, "Importance");
            AddToken(0x13, "MessageClass");
            AddToken(0x14, "Subject");
            AddToken(0x15, "Read");
            AddToken(0x16, "To");
            AddToken(0x17, "CC");
            AddToken(0x18, "From");
            AddToken(0x19, "ReplyTo");
            AddToken(0x1A, "AllDayEvent");
            AddToken(0x1B, "Categories");
            AddToken(0x1C, "Category");
            AddToken(0x1D, "DTStamp");
            AddToken(0x1E, "EndTime");
            AddToken(0x1F, "InstanceType");
            AddToken(0x20, "IntDBusyStatus");
            AddToken(0x21, "Location");
            AddToken(0x22, "MeetingRequest");
            AddToken(0x23, "Organizer");
            AddToken(0x24, "RecurrenceId");
            AddToken(0x25, "Reminder");
            AddToken(0x26, "ResponseRequested");
            AddToken(0x27, "Recurrences");
            AddToken(0x28, "Recurrence");
            AddToken(0x29, "Recurrence_Type");
            AddToken(0x2A, "Recurrence_Until");
            AddToken(0x2B, "Recurrence_Occurrences");
            AddToken(0x2C, "Recurrence_Interval");
            AddToken(0x2D, "Recurrence_DayOfWeek");
            AddToken(0x2E, "Recurrence_DayOfMonth");
            AddToken(0x2F, "Recurrence_WeekOfMonth");
            AddToken(0x30, "Recurrence_MonthOfYear");
            AddToken(0x31, "StartTime");
            AddToken(0x32, "Sensitivity");
            AddToken(0x33, "TimeZone");
            AddToken(0x34, "GlobalObjId");
            AddToken(0x35, "ThreadTopic");
            AddToken(0x36, "MIMEData");
            AddToken(0x37, "MIMETruncated");
            AddToken(0x38, "MIMESize");
            AddToken(0x39, "InternetCPID");
            AddToken(0x3A, "Flag");
            AddToken(0x3B, "FlagStatus");
            AddToken(0x3C, "ContentClass");
            AddToken(0x3D, "FlagType");
            AddToken(0x3E, "CompleteTime");
            AddToken(0x3F, "DisallowNewTimeProposal");
        }
    }
}
