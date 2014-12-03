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
    internal class SearchCodePage : TagCodePage
    {
        public SearchCodePage()
        {
            //Tokens 6 and 16 are not supported
            AddToken(0x05, "Search");
            AddToken(0x07, "Store");
            AddToken(0x08, "Name");
            AddToken(0x09, "Query");
            AddToken(0x0A, "Options");
            AddToken(0x0B, "Range");
            AddToken(0x0C, "Status");
            AddToken(0x0D, "Response");
            AddToken(0x0E, "Result");
            AddToken(0x0F, "Properties");
            AddToken(0x10, "Total");
            AddToken(0x11, "EqualTo");
            AddToken(0x12, "Value");
            AddToken(0x13, "And");
            AddToken(0x14, "Or");
            AddToken(0x15, "FreeText");
            AddToken(0x17, "DeepTraversal");
            AddToken(0x18, "LongId");
            AddToken(0x19, "RebuildResults");
            AddToken(0x1A, "LessThan");
            AddToken(0x1B, "GreaterThan");
            AddToken(0x1C, "Schema");
            AddToken(0x1D, "Supported");
            AddToken(0x1E, "UserName");
            AddToken(0x1F, "Password");
            AddToken(0x20, "ConversationId");
        }
    }
}