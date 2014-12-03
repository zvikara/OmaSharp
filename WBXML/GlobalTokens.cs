using System;
using System.Collections.Generic;

namespace WBXML
{
    public class GlobalTokens
    {
        #region Names enum

        public enum Names
        {
            SWITCH_PAGE = 0x00,
            END = 0x01,
            ENTITY = 0x02,
            STR_I = 0x03,
            LITERAL = 0x04,
            EXT_I_0 = 0x40,
            EXT_I_1 = 0x41,
            EXT_I_2 = 0x42,
            PI = 0x43,
            LITERAL_C = 0x44,
            EXT_T_0 = 0x80,
            EXT_T_1 = 0x81,
            EXT_T_2 = 0x82,
            STR_T = 0x83,
            LITERAL_A = 0x84,
            EXT_0 = 0xC0,
            EXT_1 = 0xC1,
            EXT_2 = 0xC2,
            OPAQUE = 0xC3,
            LITERAL_AC = 0xC4
        }

        #endregion

        private readonly Dictionary<byte, Names> tokenDictionary = new Dictionary<byte, Names>();

        public GlobalTokens()
        {
            foreach (String tokenName in Enum.GetNames(typeof (Names)))
            {
                var tokenItem = (Names) Enum.Parse(typeof (Names), tokenName);
                tokenDictionary.Add((byte) tokenItem, tokenItem);
            }
        }

        public bool Contains(byte keyValue)
        {
            return tokenDictionary.ContainsKey(keyValue);
        }

        public Names GetToken(byte byteValue)
        {
            return tokenDictionary[byteValue];
        }
    }
}