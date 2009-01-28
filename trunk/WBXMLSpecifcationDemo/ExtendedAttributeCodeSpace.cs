﻿// Copyright 2009 - Johan de Koning (johan@johandekoning.nl)
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
// Encoding sample which can be found inside section 8.2 of the WBXML Specification
using System;
using System.Collections.Generic;
using System.Text;
using WBXML;

namespace WBXMLSpecifcationDemo
{
    public class ExtendedAttributeCodeSpace : AttributeCodeSpace
    {
        public ExtendedAttributeCodeSpace()
        {
            AttributeCodePage codePage = new AttributeCodePage();
            codePage.AddAttributeStart(0x05, "STYLE", "LIST");
            codePage.AddAttributeStart(0x06, "TYPE");
            codePage.AddAttributeStart(0x07, "TYPE", "TEXT");
            codePage.AddAttributeStart(0x08, "URL", "http://");
            codePage.AddAttributeStart(0x09, "NAME");
            codePage.AddAttributeStart(0x0A, "KEY");

            codePage.AddAttributeValue(0x85, ".org");
            codePage.AddAttributeValue(0x86, "ACCEPT");

            AddCodePage(codePage);
        }
    }
}