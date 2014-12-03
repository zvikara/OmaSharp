using System.Collections.Generic;

namespace WBXML
{
    public abstract class TagCodeSpace
    {
        private readonly List<TagCodePage> codePages = new List<TagCodePage>();

        public void AddCodePage(TagCodePage codePage)
        {
            codePages.Add(codePage);
        }

        public virtual TagCodePage GetCodePage(int codepageId)
        {
            return codePages[codepageId];
        }

        public int ContainsTag(int codepageId, string name)
        {
            if (codePages[codepageId].ContainsTag(name))
            {
                return codepageId;
            }

            for (int i = 0; i < codePages.Count; i++)
            {
                if (i != codepageId)
                {
                    if (codePages[i].ContainsTag(name))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public abstract int GetPublicIdentifier();
    }
}