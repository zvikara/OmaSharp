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
// The WAP Binary XML (WBXML) specification is develop by the 
// Open Mobile Alliance (http://www.openmobilealliance.org/)
// Details about this specification can be found at
// http://www.openmobilealliance.org/tech/affiliates/wap/wap-192-wbxml-20010725-a.pdf

using System;
using System.Collections.Generic;
using System.Text;
using WBXML;

namespace SyncMLDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Encoding and decoding of DevInf sample (Section 9)
            //http://www.openmobilealliance.org/tech/affiliates/syncml/syncml_devinf_v11_20020215.pdf
            WBXMLDocument devInfDocument = new WBXMLDocument();
            devInfDocument.VersionNumber = 1.3;
            devInfDocument.TagCodeSpace = new DevInfCodeSpace();
            devInfDocument.Load("DevInf.xml");

            Console.WriteLine("DevInf: WBXML output");
            byte[] devInfBytes = devInfDocument.GetBytes();
            Console.WriteLine(PrintHex(devInfBytes));
            
            WBXMLDocument decodeDevInfDocument = new WBXMLDocument();
            decodeDevInfDocument.TagCodeSpace = new DevInfCodeSpace();
            decodeDevInfDocument.LoadBytes(devInfBytes);

            Console.WriteLine("DevInf: XML output");
            Console.WriteLine(decodeDevInfDocument.OuterXml);

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
