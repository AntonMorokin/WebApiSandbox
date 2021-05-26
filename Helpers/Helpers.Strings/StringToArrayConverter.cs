using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Helpers.Strings
{
    public static class StringToArrayConverter
    {
        private static Regex __hexChecker = new Regex("^[0-9,A-F,a-f]+$", RegexOptions.Compiled);

        public static byte[] FromHexStringToByteArray(string hexString)
        {
            CheckValue(hexString);

            var bytes = new List<byte>(hexString.Length / 2);

            for (int i = 0; i < hexString.Length; i += 2)
            {
                bytes.Add(Convert.ToByte(hexString[i..(i + 2)], 16));
            }

            return bytes.ToArray();
        }

        private static void CheckValue(string hexString)
        {
            if (string.IsNullOrWhiteSpace(hexString))
            {
                throw new ArgumentException("Input string cannot be empty", nameof(hexString));
            }

            if (!__hexChecker.IsMatch(hexString))
            {
                throw new ArgumentException("Input string must be in HEX format", nameof(hexString));
            }
        }
    }
}
