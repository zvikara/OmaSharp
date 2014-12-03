using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace WBXML.Tests
{
    public static class ExtensionsMethods
    {
        public static string ToHexString(this byte[] byteArray)
        {
            return BitConverter.ToString(byteArray);
        }

        public static string ToIndentedString(this XmlDocument doc)
        {
            using (var stream = new MemoryStream())
            using (var writer = new XmlTextWriter(stream, Encoding.UTF8) { Formatting = Formatting.Indented })
            using (var reader = new StreamReader(stream))
            {
                doc.Save(writer);
                stream.Position = 0;
                return reader.ReadToEnd();
            }
        }
    }
}
