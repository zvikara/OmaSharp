using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OmaSharp.WapProvisioning
{
    public static class ImsiExtensions
    {
        public static byte[] SwapBcdBytes(this long imsi) 
            => imsi
            .ToString()
            .Reverse()
            .PadToEvenLength('9')
            .BcdBytes()
            .Reverse()
            .ToArray();

        public static string Reverse(this string text)
        {
            var chars = text.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        private static IEnumerable<byte> BcdBytes(this string bcd)
        {
            for (var i = 0; i < bcd.Length / 2; i++)
            {
                var byteString = bcd.Substring(i * 2, 2);
                yield return byte.Parse(byteString, NumberStyles.HexNumber);
            }
        }

        public static byte[] SwapBcdBytes1(this long imsi)
            => imsi.SwapBcdString().BcdBytes().ToArray();

        public static string SwapBcdString(this long value)
            => value.ToString().SwapBcdString();

        private static string SwapBcdString(this string text)
            => new string(text
                ?.PadToEvenLength('F')
                ?.SwapOddEvenChars()
                ?.ToArray());

        private static string PadToEvenLength(this string text, char paddingChar)
            => text.Length.IsOdd() ? text + paddingChar : text;

        private static IEnumerable<char> SwapOddEvenChars(this string text)
            => text.Select((c, i) => i.IsOdd() ? text[i - 1] : text[i + 1]);

        private static bool IsOdd(this int number)
            => number % 2 == 1;
    }
}
