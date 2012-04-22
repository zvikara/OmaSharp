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
//
// The ActiveSync WAP Binary XML (MS-ASWBXML) specification is 
// developed by Microsoft (http://www.microsoft.com/)
// Details about this specification can be found at 
// http://msdn.microsoft.com/en-us/library/dd299442.aspx

using WBXML;

namespace ActiveSyncDemo
{
    public class ContactsCodePage : TagCodePage
    {
        public ContactsCodePage()
        {
            AddToken(0x05, "Anniversary");
            AddToken(0x06, "AssistantName");
            AddToken(0x07, "AssistantTelephoneNumber");
            AddToken(0x08, "Birthday");
            AddToken(0x09, "Body");
            AddToken(0x0A, "BodySize");
            AddToken(0x0B, "BodyTruncated");
            AddToken(0x0C, "Business2TelephoneNumber");
            AddToken(0x0D, "BusinessAddressCity");
            AddToken(0x0E, "BusinessAddressCountry");
            AddToken(0x0F, "BusinessAddressPostalCode");
            AddToken(0x10, "BusinessAddressState");
            AddToken(0x11, "BusinessAddressStreet");
            AddToken(0x12, "BusinessFaxNumber");
            AddToken(0x13, "BusinessTelephoneNumber");
            AddToken(0x14, "CarTelephoneNumber");
            AddToken(0x15, "Categories");
            AddToken(0x16, "Category");
            AddToken(0x17, "Children");
            AddToken(0x18, "Child");
            AddToken(0x19, "CompanyName");
            AddToken(0x1A, "Department");
            AddToken(0x1B, "Email1Address");
            AddToken(0x1C, "Email2Address");
            AddToken(0x1D, "Email3Address");
            AddToken(0x1E, "FileAs");
            AddToken(0x1F, "FirstName");
            AddToken(0x20, "Home2TelephoneNumber");
            AddToken(0x21, "HomeAddressCity");
            AddToken(0x22, "HomeAddressCountry");
            AddToken(0x23, "HomeAddressPostalCode");
            AddToken(0x24, "HomeAddressState");
            AddToken(0x25, "HomeAddressStreet");
            AddToken(0x26, "HomeFaxNumber");
            AddToken(0x27, "HomeTelephoneNumber");
            AddToken(0x28, "JobTitle");
            AddToken(0x29, "LastName");
            AddToken(0x2A, "MiddleName");
            AddToken(0x2B, "MobilePhoneNumber");
            AddToken(0x2C, "OfficeLocation");
            AddToken(0x2D, "OtherAddressCity");
            AddToken(0x2E, "OtherAddressCountry");
            AddToken(0x2F, "OtherAddressPostalCode");
            AddToken(0x30, "OtherAddressState");
            AddToken(0x31, "OtherAddressStreet");
            AddToken(0x32, "PagerNumber");
            AddToken(0x33, "RadioTelephoneNumber");
            AddToken(0x34, "Spouse");
            AddToken(0x35, "Suffix");
            AddToken(0x36, "Title");
            AddToken(0x37, "Webpage");
            AddToken(0x38, "YomiCompanyName");
            AddToken(0x39, "YomiFirstName");
            AddToken(0x3A, "YomiLastName");
            AddToken(0x3B, "CompressedRTF");
            AddToken(0x3C, "Picture");
            AddToken(0x3D, "Alias");
            AddToken(0x3E, "WeightedRank");
        }
    }
}