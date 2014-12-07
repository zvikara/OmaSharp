using System.Collections.Generic;
using System.Text;

namespace OmaSharp.WBXML
{
    public class IanaCharacterSets
    {
        private static readonly Dictionary<string, int> CharacterSets = new Dictionary<string, int>
        {
            {"us-ascii", 3},
            {"iso-8859-1", 4},
            {"iso-8859-2", 5},
            {"iso-8859-3", 6},
            {"iso-8859-4", 7},
            {"iso-8859-5", 8},
            {"ASMO-708", 9},
            {"iso-8859-6", 9},
            {"iso-8859-7", 10},
            {"iso-8859-8", 11},
            {"iso-8859-9", 12},
            {"shift_jis", 17},
            {"EUC-JP", 18},
            {"ks_c_5601-1987", 36},
            {"iso-2022-kr", 37},
            {"euc-kr", 38},
            {"iso-2022-jp", 39},
            {"csISO2022JP", 39},
            {"iso-8859-8-i", 85},
            {"utf-8", 106},
            {"iso-8859-13", 109},
            {"iso-8859-15", 111},
            {"GB18030", 114},
            {"utf-7", 1012},
            {"utf-16", 1015},
            {"utf-32", 1017},
            {"utf-32BE", 1018},
            {"ibm850", 2009},
            {"ibm852", 2010},
            {"IBM437", 2011},
            {"IBM-Thai", 2016},
            {"gb2312", 2025},
            {"big5", 2026},
            {"macintosh", 2027},
            {"IBM037", 2028},
            {"IBM273", 2030},
            {"IBM277", 2033},
            {"IBM278", 2034},
            {"IBM280", 2035},
            {"IBM284", 2037},
            {"IBM285", 2038},
            {"IBM290", 2039},
            {"IBM297", 2040},
            {"IBM420", 2041},
            {"IBM423", 2042},
            {"IBM424", 2043},
            {"IBM500", 2044},
            {"IBM855", 2046},
            {"ibm857", 2047},
            {"IBM860", 2048},
            {"ibm861", 2049},
            {"IBM863", 2050},
            {"IBM864", 2051},
            {"IBM865", 2052},
            {"ibm869", 2054},
            {"IBM870", 2055},
            {"IBM871", 2056},
            {"IBM880", 2057},
            {"IBM905", 2061},
            {"IBM1026", 2063},
            {"koi8-r", 2084},
            {"hz-gb-2312", 2085},
            {"cp866", 2086},
            {"ibm775", 2087},
            {"koi8-u", 2088},
            {"IBM00858", 2089},
            {"IBM00924", 2090},
            {"IBM01140", 2091},
            {"IBM01141", 2092},
            {"IBM01142", 2093},
            {"IBM01143", 2094},
            {"IBM01144", 2095},
            {"IBM01145", 2096},
            {"IBM01146", 2097},
            {"IBM01147", 2098},
            {"IBM01148", 2099},
            {"IBM01149", 2100},
            {"IBM01047", 2102},
            {"windows-1250", 2250},
            {"windows-1251", 2251},
            {"Windows-1252", 2252},
            {"windows-1253", 2253},
            {"windows-1254", 2254},
            {"windows-1255", 2255},
            {"windows-1256", 2256},
            {"windows-1257", 2257},
            {"windows-1258", 2258}
        };

        public static Encoding GetEncoding(int MIBenum)
        {
            if (!CharacterSets.ContainsValue(MIBenum)) return Encoding.UTF8;
            foreach (var characterSet in CharacterSets)
                if (characterSet.Value == MIBenum)
                    return Encoding.GetEncoding(characterSet.Key);
            return Encoding.UTF8;
        }

        public static int GetMIBEnum(Encoding encoding)
        {
            return CharacterSets.ContainsKey(encoding.WebName) ? 
                CharacterSets[encoding.WebName] : CharacterSets["utf-8"];
        }
    }
}