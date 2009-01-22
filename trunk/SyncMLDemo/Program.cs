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
            byte[] byteArray = new byte[] { }; //The WBXML which is used for the SyncML protocol
           
            WBXMLDocument wbxmlDocument = new WBXMLDocument();
            wbxmlDocument.TagCodeSpace = new SyncMLCodeSpace();
            wbxmlDocument.LoadBytes(byteArray);
            Console.WriteLine(wbxmlDocument.OuterXml);
            Console.ReadLine();    
        }
    }
}
