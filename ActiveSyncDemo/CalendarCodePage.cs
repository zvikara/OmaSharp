using OmaSharp.WBXML;

namespace ActiveSyncDemo
{
    public class CalendarCodePage : TagCodePage
    {
        public CalendarCodePage()
        {
            AddToken(0x05, "TimeZone");
            AddToken(0x06, "AllDayEvent");
            AddToken(0x07, "Attendees");
            AddToken(0x08, "Attendee");
            AddToken(0x09, "Attendee_Email");
            AddToken(0x0A, "Attendee_Name");
            AddToken(0x0B, "Body");
            AddToken(0x0C, "BodyTruncated");
            AddToken(0x0D, "BusyStatus");
            AddToken(0x0E, "Categories");
            AddToken(0x0F, "Category");
            AddToken(0x10, "Compressed_RTF");
            AddToken(0x11, "DTStamp");
            AddToken(0x12, "EndTime");
            AddToken(0x13, "Exception");
            AddToken(0x14, "Exceptions");
            AddToken(0x15, "Exception_IsDeleted");
            AddToken(0x16, "Exception_StartTime");
            AddToken(0x17, "Location");
            AddToken(0x18, "MeetingStatus");
            AddToken(0x19, "Organizer_Email");
            AddToken(0x1A, "Organizer_Name");
            AddToken(0x1B, "Recurrence");
            AddToken(0x1C, "Recurrence_Type");
            AddToken(0x1D, "Recurrence_Until");
            AddToken(0x1E, "Recurrence_Occurrences");
            AddToken(0x1F, "Recurrence_Interval");
            AddToken(0x20, "Recurrence_DayOfWeek");
            AddToken(0x21, "Recurrence_DayOfMonth");
            AddToken(0x22, "Recurrence_WeekOfMonth");
            AddToken(0x23, "Recurrence_MonthOfYear");
            AddToken(0x24, "Reminder_MinsBefore");
            AddToken(0x25, "Sensitivity");
            AddToken(0x26, "Subject");
            AddToken(0x27, "StartTime");
            AddToken(0x28, "UID");
            AddToken(0x29, "Attendee_Status");
            AddToken(0x2A, "Attendee_Type");
            AddToken(0x2B, "Attachment");
            AddToken(0x2C, "Attachments");
            AddToken(0x2D, "AttName");
            AddToken(0x2E, "AttSize");
            AddToken(0x2F, "AttOid");
            AddToken(0x30, "AttMethod");
            AddToken(0x31, "AttRemoved");
            AddToken(0x32, "DisplayName");
            AddToken(0x33, "DisallowNewTimeProposal");
            AddToken(0x34, "ResponseRequested");
            AddToken(0x35, "AppointmentReplyTime");
            AddToken(0x36, "ResponseType");
        }
    }
}