using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tomi.IdentityNumber
{
    public class TaiwanIdentityNumberCheckSum
    {
        private static readonly string words = "0123456789ABCDEFGHJKLMNPQRSTUVXYWZIO";

        private static readonly Dictionary<char, int> wordPairs = Enumerable.Range(0, words.Length).ToDictionary(m => words[m]);

        private static readonly int[] weights = new int[] { 1, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1 };

        private static readonly string pattern = "^[A-Z]{1}[1289A-D]{1}[0-9]{7}";

        public static char CalculateCheckSum(string identityNumber)
        {
            if (string.IsNullOrWhiteSpace(identityNumber))
                throw new ArgumentNullException(nameof(identityNumber));
            if (!Regex.IsMatch(identityNumber, pattern))
                throw new FormatException($"{nameof(identityNumber)} invalid format.");

            var result = 0;
            for (int i = 0; i < 9; i++)
            {
                var c = identityNumber[i];
                var v = wordPairs[c];
                if (i == 0)
                {
                    result += v / 10 * weights[0] + v % 10 * weights[1];
                }
                else
                {
                    result += v * weights[i + 1];
                }
            }

            var mod = (10 - (result % 10)) % 10;
            return words[mod];
        }
    }
}
