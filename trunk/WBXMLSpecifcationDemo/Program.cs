// Copyright 2009 - Johan de Koning (johan@johandekoning.nl)
// 
// This file is part of WBXML .Net Library.
// The WBXML .Net Library is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// The WBXML .Net Library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// The WAP Binary XML (WBXML) specification is developed by the 
// Open Mobile Alliance (http://www.openmobilealliance.org/)
// Details about this specification can be found at
// http://www.openmobilealliance.org/tech/affiliates/wap/wap-192-wbxml-20010725-a.pdf
//
// Encoding sample which can be found inside section 8.1 of the WBXML Specification
using System;
using System.Collections.Generic;
using System.Text;
using WBXML;

namespace WBXMLSpecifcationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WBXMLDocument simpleWBXMLDocument = new WBXMLDocument();
            simpleWBXMLDocument.Load("SimpleXML.xml");
            simpleWBXMLDocument.VersionNumber = 1.3;
            simpleWBXMLDocument.TagCodeSpace = new SimpleCodeSpace();

            Console.WriteLine("Simple: WBXML output");
            byte[] simpleBytes = simpleWBXMLDocument.GetBytes();
            Console.WriteLine(PrintHex(simpleBytes));
            
            WBXMLDocument decodeSimpleWBXMLDocument = new WBXMLDocument();
            decodeSimpleWBXMLDocument.TagCodeSpace = new SimpleCodeSpace();
            decodeSimpleWBXMLDocument.LoadBytes(simpleBytes);

            Console.WriteLine("Simple: XML output");            
            Console.WriteLine(decodeSimpleWBXMLDocument.OuterXml);

            WBXMLDocument extendedWBXMLDocument = new WBXMLDocument();
            extendedWBXMLDocument.Load("ExtendedXML.xml");
            extendedWBXMLDocument.VersionNumber = 1.3;
            extendedWBXMLDocument.TagCodeSpace = new ExtendedCodeSpace();
            extendedWBXMLDocument.AttributeCodeSpace = new ExtendedAttributeCodeSpace();

            Console.WriteLine("Extended: WBXML output");
            byte[] extendedBytes = extendedWBXMLDocument.GetBytes();
            Console.WriteLine(PrintHex(extendedBytes));

            WBXMLDocument decodeExtendedWBXMLDocument = new WBXMLDocument();
            decodeExtendedWBXMLDocument.TagCodeSpace = new ExtendedCodeSpace();
            decodeExtendedWBXMLDocument.AttributeCodeSpace = new AttributeCodeSpace();
            decodeExtendedWBXMLDocument.LoadBytes(extendedBytes);

            Console.WriteLine("Extended: XML output");
            Console.WriteLine(decodeExtendedWBXMLDocument.OuterXml);
            Console.ReadLine();
        }

        private static string PrintHex(byte[] bytes)
        {
            StringBuilder stringReturn = new StringBuilder();
            foreach (byte byteItem in bytes)
            {
                stringReturn.Append(byteItem.ToString("X2"));
                stringReturn.Append(" ");
            }
            return stringReturn.ToString();
        }
    }
}
