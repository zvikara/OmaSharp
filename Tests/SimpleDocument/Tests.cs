using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OmaSharp.WBXML;

namespace OmaSharp.Tests.SimpleDocument
{

    [TestFixture]
    public class Tests
    {
        private static readonly string ns = typeof(Tests).Namespace.Split('.').Last();

        private static readonly string xmlPath
            = Path.Combine(TestContext.CurrentContext.TestDirectory, $"../../{ns}/XML.xml");

        public static readonly string xml = File.ReadAllText(xmlPath, Encoding.UTF8);

        // Encoding sample which can be found inside section 8.1 of the WBXML Specification
        [Test]
        public void EncodeAndDecode()
        {
            const string expectedBytes =
                "03-01-03-00-47-46-03-20-58-20-26-20-59-00-05-03-20-58-00-02-81-20-03-3D-00-02-81-20-03-31-20-00-01-01";
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

            document.RemoveCommentsAndDtd();
            Assert.AreEqual(document.ToIndentedString(), decodedDocument.ToIndentedString());
        }
    }
}
