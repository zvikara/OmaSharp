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
// Details about the IANA Character Sets can be found at
// http://www.iana.org/assignments/character-sets
using System;
using System.Collections.Generic;
using System.Text;

namespace WBXML
{
    public class IANACharacterSets
    {
        private static Dictionary<string, int> characterSets;

        public static Encoding GetEncoding(int MIBenum)
        {
            if (characterSets == null)
            {
                InitializeCharacterSets();
            }

            if (characterSets.ContainsValue(MIBenum))
            {
                foreach (KeyValuePair<string, int> characterSet in characterSets)
                {
                    if (characterSet.Value == MIBenum)
                    {
                        return Encoding.GetEncoding(characterSet.Key);
                    }
                }
            }
            return Encoding.UTF8;
        }

        public static int GetMIBEnum(Encoding encoding)
        {
            if (characterSets == null)
            {
                InitializeCharacterSets();
            }

            if (characterSets.ContainsKey(encoding.WebName))
            {
                return characterSets[encoding.WebName];
            }
            return characterSets["utf-8"];
        }

        private static void InitializeCharacterSets()
        {
            characterSets = new Dictionary<string, int>();

            characterSets.Add("us-ascii", 3);
            characterSets.Add("iso-8859-1", 4);
            characterSets.Add("iso-8859-2", 5);
            characterSets.Add("iso-8859-3", 6);
            characterSets.Add("iso-8859-4", 7);
            characterSets.Add("iso-8859-5", 8);
            characterSets.Add("ASMO-708", 9);
            characterSets.Add("iso-8859-6", 9);
            characterSets.Add("iso-8859-7", 10);
            characterSets.Add("iso-8859-8", 11);
            characterSets.Add("iso-8859-9", 12);
            characterSets.Add("shift_jis", 17);
            characterSets.Add("EUC-JP", 18);
            characterSets.Add("ks_c_5601-1987", 36);
            characterSets.Add("iso-2022-kr", 37);
            characterSets.Add("euc-kr", 38);
            characterSets.Add("iso-2022-jp", 39);
            characterSets.Add("csISO2022JP", 39);
            characterSets.Add("iso-8859-8-i", 85);
            characterSets.Add("utf-8", 106);
            characterSets.Add("iso-8859-13", 109);
            characterSets.Add("iso-8859-15", 111);
            characterSets.Add("GB18030", 114);
            characterSets.Add("utf-7", 1012);
            characterSets.Add("utf-16", 1015);
            characterSets.Add("utf-32", 1017);
            characterSets.Add("utf-32BE", 1018);
            characterSets.Add("ibm850", 2009);
            characterSets.Add("ibm852", 2010);
            characterSets.Add("IBM437", 2011);
            characterSets.Add("IBM-Thai", 2016);
            characterSets.Add("gb2312", 2025);
            characterSets.Add("big5", 2026);
            characterSets.Add("macintosh", 2027);
            characterSets.Add("IBM037", 2028);
            characterSets.Add("IBM273", 2030);
            characterSets.Add("IBM277", 2033);
            characterSets.Add("IBM278", 2034);
            characterSets.Add("IBM280", 2035);
            characterSets.Add("IBM284", 2037);
            characterSets.Add("IBM285", 2038);
            characterSets.Add("IBM290", 2039);
            characterSets.Add("IBM297", 2040);
            characterSets.Add("IBM420", 2041);
            characterSets.Add("IBM423", 2042);
            characterSets.Add("IBM424", 2043);
            characterSets.Add("IBM500", 2044);
            characterSets.Add("IBM855", 2046);
            characterSets.Add("ibm857", 2047);
            characterSets.Add("IBM860", 2048);
            characterSets.Add("ibm861", 2049);
            characterSets.Add("IBM863", 2050);
            characterSets.Add("IBM864", 2051);
            characterSets.Add("IBM865", 2052);
            characterSets.Add("ibm869", 2054);
            characterSets.Add("IBM870", 2055);
            characterSets.Add("IBM871", 2056);
            characterSets.Add("IBM880", 2057);
            characterSets.Add("IBM905", 2061);
            characterSets.Add("IBM1026", 2063);
            characterSets.Add("koi8-r", 2084);
            characterSets.Add("hz-gb-2312", 2085);
            characterSets.Add("cp866", 2086);
            characterSets.Add("ibm775", 2087);
            characterSets.Add("koi8-u", 2088);
            characterSets.Add("IBM00858", 2089);
            characterSets.Add("IBM00924", 2090);
            characterSets.Add("IBM01140", 2091);
            characterSets.Add("IBM01141", 2092);
            characterSets.Add("IBM01142", 2093);
            characterSets.Add("IBM01143", 2094);
            characterSets.Add("IBM01144", 2095);
            characterSets.Add("IBM01145", 2096);
            characterSets.Add("IBM01146", 2097);
            characterSets.Add("IBM01147", 2098);
            characterSets.Add("IBM01148", 2099);
            characterSets.Add("IBM01149", 2100);
            characterSets.Add("IBM01047", 2102);
            characterSets.Add("windows-1250", 2250);
            characterSets.Add("windows-1251", 2251);
            characterSets.Add("Windows-1252", 2252);
            characterSets.Add("windows-1253", 2253);
            characterSets.Add("windows-1254", 2254);
            characterSets.Add("windows-1255", 2255);
            characterSets.Add("windows-1256", 2256);
            characterSets.Add("windows-1257", 2257);
            characterSets.Add("windows-1258", 2258);
        }

    }
}
