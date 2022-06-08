using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Tomi.IdentityNumber
{
    public class TaiwanResideNumberV1 : IIdentityNumber
    {
        private static readonly string Pattern = "^[A-Z]{1}[A-D]{1}[0-9]{8}$";
        public bool Verify(string identityNumber)
        {
            if (string.IsNullOrWhiteSpace(identityNumber)) return false;
            if (!Regex.IsMatch(identityNumber, Pattern)) return false;
            var checkSum = TaiwanIdentityNumberCheckSum.CalculateCheckSum(identityNumber);
            if (identityNumber[^1] != checkSum) return false;
            return true;
        }

        static readonly char[] first = Enumerable.Range(0, 26).Select(m => Convert.ToChar(0x41 + m)).ToArray();
        static readonly char[] second = Enumerable.Range(0, 4).Select(m => Convert.ToChar(0x41 + m)).ToArray();

        public string Generate()
        {
            var sb = new StringBuilder(10);
            sb.Append(first[RandomNumberGenerator.GetInt32(first.Length)]);
            sb.Append(second[RandomNumberGenerator.GetInt32(second.Length)]);
            sb.AppendFormat("{0:0000000}", RandomNumberGenerator.GetInt32(10000000));
            sb.Append(TaiwanIdentityNumberCheckSum.CalculateCheckSum(sb.ToString()));
            return sb.ToString();
        }
    }
}
