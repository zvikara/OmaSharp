// Copyright 2012 - Johan de Koning (johan@johandekoning.nl)
// 
// This file is part of WBXML .Net Library.
// Permission is hereby granted, free of charge, to any person obtaining a copy 
// of this software and associated documentation files (the "Software"), to deal in 
// the Software without restriction, including without limitation the rights to use, 
// copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the 
// Software, and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies 
// or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE 
// USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// The WAP Binary XML (WBXML) specification is developed by the 
// Open Mobile Alliance (http://www.openmobilealliance.org/)
// Details about this specification can be found at
// http://www.openmobilealliance.org/tech/affiliates/wap/wap-192-wbxml-20010725-a.pdf
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