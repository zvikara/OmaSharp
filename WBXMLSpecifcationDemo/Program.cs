// Encoding sample which can be found inside section 8.1 of the WBXML Specification
using System;
using System.Text;
using WBXML;

namespace WBXMLSpecifcationDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var simpleWBXMLDocument = new WBXMLDocument();
            simpleWBXMLDocument.Load("SimpleXML.xml");
            simpleWBXMLDocument.VersionNumber = 1.3;
            simpleWBXMLDocument.TagCodeSpace = new SimpleCodeSpace();
            simpleWBXMLDocument.Encoding = Encoding.ASCII;

            Console.WriteLine("Simple: WBXML output");
            byte[] simpleBytes = simpleWBXMLDocument.GetBytes();
            Console.WriteLine(PrintHex(simpleBytes));

            var decodeSimpleWBXMLDocument = new WBXMLDocument();
            decodeSimpleWBXMLDocument.TagCodeSpace = new SimpleCodeSpace();
            decodeSimpleWBXMLDocument.LoadBytes(simpleBytes);

            Console.WriteLine("Simple: XML output");
            Console.WriteLine(decodeSimpleWBXMLDocument.OuterXml);

            var extendedWBXMLDocument = new WBXMLDocument();
            extendedWBXMLDocument.Load("ExtendedXML.xml");
            extendedWBXMLDocument.VersionNumber = 1.3;
            extendedWBXMLDocument.TagCodeSpace = new ExtendedCodeSpace();
            extendedWBXMLDocument.AttributeCodeSpace = new ExtendedAttributeCodeSpace();
            extendedWBXMLDocument.StringTable = new StringTable(new[] {"abc", " Enter name: "});

            Console.WriteLine("Extended: WBXML output");
            byte[] extendedBytes = extendedWBXMLDocument.GetBytes();
            Console.WriteLine(PrintHex(extendedBytes));

            var decodeExtendedWBXMLDocument = new WBXMLDocument();
            decodeExtendedWBXMLDocument.TagCodeSpace = new ExtendedCodeSpace();
            decodeExtendedWBXMLDocument.AttributeCodeSpace = new ExtendedAttributeCodeSpace();
            decodeExtendedWBXMLDocument.LoadBytes(extendedBytes);

            Console.WriteLine("Extended: XML output");
            Console.WriteLine(decodeExtendedWBXMLDocument.OuterXml);
            Console.ReadLine();
        }

        private static string PrintHex(byte[] bytes)
        {
            var stringReturn = new StringBuilder();
            foreach (byte byteItem in bytes)
            {
                stringReturn.Append(byteItem.ToString("X2"));
                stringReturn.Append(" ");
            }
            return stringReturn.ToString();
        }
    }
}