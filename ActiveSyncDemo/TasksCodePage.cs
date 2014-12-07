using OmaSharp.WBXML;

namespace ActiveSyncDemo
{
    internal class TasksCodePage : TagCodePage
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