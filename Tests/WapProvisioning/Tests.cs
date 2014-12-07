using System.IO;
using System.Text;
using System.Xml;
using NUnit.Framework;
using OmaSharp.WapProvisioning;
using OmaSharp.WBXML;

// Encoding xml message example 1 from section 6.1 of OMA-WAP-TS-ProvCont-V1_1-20090728-A
namespace OmaSharp.Tests.WapProvisioning
{
    [TestFixture]
    public class Tests
    {
        const string ExpectedBytes =
            "03-0B-6A-05-4E-41-50-31-00-C5-46-01-C6-51-01-87-15-06-03-31-37-30-2E-31-38-37-2E-35-31-2E-34-00-01-87-07-06-03-42-61-6E-6B-4D-61-69-6E-50-72-6F-78-79-00-01-87-1C-06-03-68-74-74-70-3A-2F-2F-77-77-77-2E-62-61-6E-6B-2E-63-6F-6D-2F-73-74-61-72-74-70-61-67-65-2E-77-6D-6C-00-01-C6-59-01-87-19-06-9C-01-87-1A-06-03-70-78-75-73-65-72-6E-61-6D-65-00-01-87-1B-06-03-70-78-75-73-65-72-70-61-73-73-77-64-00-01-01-C6-52-01-87-2F-06-03-50-52-4F-58-59-20-31-00-01-87-17-06-03-77-77-77-2E-62-61-6E-6B-2E-63-6F-6D-2F-00-01-87-20-06-03-31-37-30-2E-31-38-37-2E-35-31-2E-33-00-01-87-21-06-85-01-87-22-06-03-49-4E-54-45-52-4E-45-54-00-01-87-22-06-83-00-01-C6-53-01-87-23-06-03-39-32-30-33-00-01-01-01-01-C6-55-01-87-11-06-83-00-01-87-10-06-AA-01-87-07-06-03-4D-59-20-49-53-50-20-43-53-44-00-01-87-08-06-03-2B-33-35-38-30-38-31-32-34-30-30-32-00-01-87-09-06-87-01-87-0A-06-90-01-C6-5A-01-87-0C-06-9A-01-87-0D-06-03-77-77-77-6D-6D-6D-75-73-65-72-00-01-87-0E-06-03-77-77-77-6D-6D-6D-73-65-63-72-65-74-00-01-01-C6-54-01-87-12-06-03-32-32-38-00-01-87-13-06-03-30-30-31-00-01-01-01-01";
        private readonly string xml = File.ReadAllText(@"WapProvisioning\XML.xml", Encoding.UTF8);

        [Test]
        public void EncodeAndDecode()
        {
            var document = new WbxmlDocument();
            document.LoadXml(xml);
            document.VersionNumber = 1.3;
            document.TagCodeSpace = new CodeSpace();
            document.AttributeCodeSpace = new AttrCodeSpace();
            document.StringTable = new StringTable(new[] { "NAP1" });

            var bytes = document.GetBytes();
            //Console.WriteLine(bytes.ToHexString());
            Assert.AreEqual(ExpectedBytes, bytes.ToHexString());

            var decodedDocument = new WbxmlDocument
            {
                TagCodeSpace = new CodeSpace(),
                AttributeCodeSpace = new AttrCodeSpace()
            };
            decodedDocument.LoadBytes(bytes);

            document.RemoveCommentsAndDtd();
            Assert.AreEqual(document.ToIndentedString(), decodedDocument.ToIndentedString());
        }

        [Test]
        public void Document()
        {
            var document = new CpDocument();
            document.LoadXml(xml);

            var bytes = document.GetBytes();
            //Console.WriteLine(bytes.ToHexString());
            Assert.AreEqual(ExpectedBytes, bytes.ToHexString());

            var decodedDocument = new CpDocument();
            decodedDocument.LoadBytes(bytes);

            document.RemoveCommentsAndDtd();
            Assert.AreEqual(document.ToIndentedString(), decodedDocument.ToIndentedString());
        }
    }
}
