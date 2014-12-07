namespace OmaSharp.WBXML
{
    public class AttributeValue
    {
        private readonly string attributeValue;
        private readonly byte token;

        public AttributeValue(byte token, string attributeValue)
        {
            this.token = token;
            this.attributeValue = attributeValue;
        }

        public byte Token
        {
            get { return token; }
        }

        public string Value
        {
            get { return attributeValue; }
        }
    }
}