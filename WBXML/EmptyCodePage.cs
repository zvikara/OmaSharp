namespace OmaSharp.WBXML
{
    public class EmptyCodePage : TagCodePage
    {
        public override bool ContainsTag(byte token)
        {
            return true;
        }

        public override Tag GetTag(byte token)
        {
            return new Tag(token, "Tag_" + token.ToString("X2"));
        }
    }
}