using System.Collections.Generic;

namespace OmaSharp.WBXML
{
    public class AttributeCodeSpace
    {
        private readonly List<AttributeCodePage> codePages = new List<AttributeCodePage>();

        public void AddCodePage(AttributeCodePage codePage)
        {
            codePages.Add(codePage);
        }

        public virtual AttributeCodePage GetCodePage(int codepageId)
        {
            return codePages[codepageId];
        }

        public int ContainsAttribute(int codepageId, string name, string attributeValue)
        {
            if (codePages[codepageId].ContainsAttribute(name, attributeValue))
            {
                return codepageId;
            }

            for (int i = 0; i < codePages.Count; i++)
            {
                if (i != codepageId)
                {
                    if (codePages[i].ContainsAttribute(name, attributeValue))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public int ContainsAttributeStart(int codepageId, string name, string attributeValue)
        {
            var cp = ContainsAttribute(codepageId, name, attributeValue);
            if (cp >= 0)
                return cp;

            if (codePages[codepageId].ContainsAttributeStart(name, attributeValue))
            {
                return codepageId;
            }

            for (int i = 0; i < codePages.Count; i++)
            {
                if (i != codepageId)
                {
                    if (codePages[i].ContainsAttributeStart(name, attributeValue))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

    }
}