using System.Collections.Generic;

namespace OmaSharp.WBXML
{
    public class TagCodePage
    {
        private readonly Dictionary<string, byte> nameDictionary = new Dictionary<string, byte>();
        private readonly Dictionary<byte, string> tokenDictionary = new Dictionary<byte, string>();

        public void AddToken(byte token, string name)
        {
            tokenDictionary.Add(token, name);
            nameDictionary.Add(name, token);
        }

        public virtual bool ContainsTag(byte token)
        {
            return tokenDictionary.ContainsKey(token);
        }

        public virtual bool ContainsTag(string name)
        {
            return nameDictionary.ContainsKey(name);
        }

        public virtual Tag GetTag(byte token)
        {
            return new Tag(token, tokenDictionary[token]);
        }

        public virtual Tag GetTag(string name)
        {
            return new Tag(nameDictionary[name], name);
        }
    }
}