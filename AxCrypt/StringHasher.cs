using System;
using System.Security.Cryptography;
using System.Text;

namespace AxCrypt
{
    public class StringHasher
    {
        private readonly Func<HashAlgorithm> _hasher;

        public StringHasher(Func<HashAlgorithm> hasher)
        {
            _hasher = hasher;
        }

        public string ComputeHash(string input)
        {
            using (HashAlgorithm hash = _hasher())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] inputHashBytes = hash.ComputeHash(inputBytes);

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
