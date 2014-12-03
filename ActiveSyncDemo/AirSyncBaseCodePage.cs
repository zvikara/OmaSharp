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
    internal class AirSyncBaseCodePage : TagCodePage
    {
        public AirSyncBaseCodePage()
        {
            AddToken(0x05, "BodyPreference");
            AddToken(0x06, "Type");
            AddToken(0x07, "TruncationSize");
            AddToken(0x08, "AllOrNone");
            AddToken(0x0A, "Body");
            AddToken(0x0B, "Data");
            AddToken(0x0C, "EstimatedDataSize");
            AddToken(0x0D, "Truncated");
            AddToken(0x0E, "Attachments");
            AddToken(0x0F, "Attachment");
            AddToken(0x10, "DisplayName");
            AddToken(0x11, "FileReference");
            AddToken(0x12, "Method");
            AddToken(0x13, "ContentId");
            AddToken(0x14, "ContentLocation");
            AddToken(0x15, "IsInline");
            AddToken(0x16, "NativeBodyType");
            AddToken(0x17, "ContentType");
            AddToken(0x18, "Preview");
        }
    }
}