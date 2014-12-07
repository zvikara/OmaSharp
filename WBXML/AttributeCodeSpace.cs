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
    }
}