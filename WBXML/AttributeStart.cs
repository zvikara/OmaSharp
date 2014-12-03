namespace WBXML
{
    public class AttributeStart
    {
        private readonly string name;
        private readonly string prefix;
        private readonly byte token;

        public AttributeStart(byte token, string name)
            : this(token, name, "")
        {
        }

        public AttributeStart(byte token, string name, string prefix)
        {
            this.token = token;
            this.name = name;
            this.prefix = prefix;
        }

        public byte Token
        {
            get { return token; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Prefix
        {
            get { return prefix; }
        }
    }
}