using System.Xml;
using NUnit.Framework;

namespace OmaSharp.Tests
{
    public abstract class XmlAssert
    {
        public static void AreEqual(XmlDocument expected, XmlDocument actual) 
            => Assert.AreEqual(
                expected.RemoveCommentsAndDtd().ToIndentedString(),
                actual.RemoveCommentsAndDtd().ToIndentedString());
    }
}
