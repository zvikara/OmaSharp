using OmaSharp.WBXML;

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
            return 0x01;
        }
    }
}