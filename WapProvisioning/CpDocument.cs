using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmaSharp.WBXML;

namespace OmaSharp.WapProvisioning
{
    public class CpDocument : WbxmlDocument
    {
        public CpDocument()
        {
            VersionNumber = 1.3;
            TagCodeSpace = new CodeSpace();
            AttributeCodeSpace = new AttrCodeSpace();
            StringTable = new StringTable(new[] { "NAP1" });
        }
    }
}
