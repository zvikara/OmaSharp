using System.IO;
using System.Text;
using NUnit.Framework;

namespace WBXML.Tests.SimpleDocument
{

    [TestFixture]
    public class Tests
    {
        // Encoding sample which can be found inside section 8.1 of the WBXML Specification
        [Test]
        public void EncodeAndDecode()
        {
            const string expectedBytes =
                "03-01-03-00-47-46-03-20-58-20-26-20-59-00-05-03-20-58-00-02-81-20-03-3D-00-02-81-20-03-31-20-00-01-01";
            var xml = File.ReadAllText(@"SimpleDocument\XML.xml", Encoding.UTF8);
            var document = new WbxmlDocument();
            document.LoadXml(xml);
            document.VersionNumber = 1.3;
            document.TagCodeSpace = new CodeSpace();
            document.Encoding = Encoding.ASCII;

            var bytes = document.GetBytes();
            //Console.WriteLine(bytes.ToHexString());
            Assert.AreEqual(expectedBytes, bytes.ToHexString());

            var decodedDocument = new WbxmlDocument
            {
                TagCodeSpace = new CodeSpace()
            };
            decodedDocument.LoadBytes(bytes);

            if (document.DocumentType != null)
                document.RemoveChild(document.DocumentType);

            Assert.AreEqual(document.ToIndentedString(), decodedDocument.ToIndentedString());
        }
    }
}
