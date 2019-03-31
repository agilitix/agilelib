using System;
using System.Security.Cryptography;
using System.Text;

namespace AxCrypt
{
    public class HashString
    {
        private readonly Func<HashAlgorithm> _hasherFactory;

        public HashString(Func<HashAlgorithm> hasherFactory)
        {
            _hasherFactory = hasherFactory;
        }

        public string ComputeHash(string input)
        {
            using (HashAlgorithm hashAlgorithm = _hasherFactory())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] inputHashBytes = hashAlgorithm.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (int index = 0; index < inputHashBytes.Length; ++index)
                {
                    byte b = inputHashBytes[index];
                    sb.Append(b.ToString("x2")); // Hexadecimal.
                }

                return sb.ToString();
            }
        }

        public bool VerifyHash(string input, string hash)
        {
            string inputHash = ComputeHash(input);
            return inputHash == hash;
        }
    }
}
