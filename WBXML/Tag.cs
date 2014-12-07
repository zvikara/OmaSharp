namespace OmaSharp.WBXML
{
    public class Tag
    {
        private readonly string name;
        private readonly byte token;

        public Tag(byte token, string name)
        {
            this.token = token;
            this.name = name;
        }

        public byte Token
        {
            get { return token; }
        }

        public string Name
        {
            get { return name; }
        }
    }
}