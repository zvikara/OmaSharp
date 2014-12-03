using WBXML;

namespace ActiveSyncDemo
{
    internal class Email2CodePage : TagCodePage
    {
        public Email2CodePage()
        {
            AddToken(0x05, "UmCallerID");
            AddToken(0x06, "UmUserNotes");
            AddToken(0x07, "UmAttDuration");
            AddToken(0x08, "UmAttOrder");
            AddToken(0x09, "ConversationId");
            AddToken(0x0A, "ConversationIndex");
            AddToken(0x0B, "LastVerbExecuted");
            AddToken(0x0C, "LastVerbExecutionTime");
            AddToken(0x0D, "ReceivedAsBcc");
            AddToken(0x0E, "Sender");
            AddToken(0x0F, "CalendarType");
            AddToken(0x10, "IsLeapMonth");
        }
    }
}