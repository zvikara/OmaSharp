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
    class TasksCodePage : TagCodePage
    {
        public TasksCodePage()
        {
            AddToken(0x05, "Body");
            AddToken(0x06, "BodySize");
            AddToken(0x07, "BodyTruncated");
            AddToken(0x08, "Categories");
            AddToken(0x09, "Category");
            AddToken(0x0A, "Complete");
            AddToken(0x0B, "DateCompleted");
            AddToken(0x0C, "DueDate");
            AddToken(0x0D, "UTCDueDate");
            AddToken(0x0E, "Importance");
            AddToken(0x0F, "Recurrence");
            AddToken(0x10, "RecurrenceType");
            AddToken(0x11, "RecurrenceStart");
            AddToken(0x12, "RecurrenceUntil");
            AddToken(0x13, "RecurrenceOccurrences");
            AddToken(0x14, "RecurrenceInterval");
            AddToken(0x15, "RecurrenceDayOfMonth");
            AddToken(0x16, "RecurrenceDayOfWeek");
            AddToken(0x17, "RecurrenceWeekOfMonth");
            AddToken(0x18, "RecurrenceMonthOfYear");
            AddToken(0x19, "RecurrenceRegenerate");
            AddToken(0x1A, "RecurrenceDeadOccur");
            AddToken(0x1B, "ReminderSet");
            AddToken(0x1C, "ReminderTime");
            AddToken(0x1D, "Sensitivity");
            AddToken(0x1E, "StartDate");
            AddToken(0x1F, "UTCStartDate");
            AddToken(0x20, "Subject");
            AddToken(0x21, "CompressedRTF");
            AddToken(0x22, "OrdinalDate");
            AddToken(0x23, "SubOrdinalDate");
        }
        
    }
}
