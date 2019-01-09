using System.IO;
using System.Text;
using System.Xml;
using NUnit.Framework;
using OmaSharp.WBXML;

namespace OmaSharp.Tests.ExtendedDocument
{

    [TestFixture]
    public class Tests
    {
        // Encoding sample which can be found inside section 8.2 of the WBXML Specification
        [Test]
        public void EncodeAndDecode()
        {
            const string expectedBytes =
                "03-01-6A-12-61-62-63-00-20-45-6E-74-65-72-20-6E-61-6D-65-3A-20-00-47-C5-09-83-00-05-01-88-06-86-08-03-78-79-7A-00-85-03-2F-73-00-01-83-04-86-07-0A-03-4E-00-01-01-01";
            var xml = File.ReadAllText(@"Tests\ExtendedDocument\XML.xml", Encoding.UTF8);
            var document = new WbxmlDocument();
            document.LoadXml(xml);
            document.VersionNumber = 1.3;
            document.TagCodeSpace = new CodeSpace();
            document.AttributeCodeSpace = new AttributeCodeSpace();
            document.StringTable = new StringTable(new[] { "abc", " Enter name: " });
            document.Encoding = Encoding.UTF8;

            var bytes = document.GetBytes();
            //Console.WriteLine(bytes.ToHexString());
            Assert.AreEqual(expectedBytes, bytes.ToHexString());

            var decodedDocument = new WbxmlDocument
            {
                TagCodeSpace = new CodeSpace(),
                AttributeCodeSpace = new AttributeCodeSpace()
            };
            decodedDocument.LoadBytes(bytes);
            XmlAssert.AreEqual(document, decodedDocument);
        }
    }
}
