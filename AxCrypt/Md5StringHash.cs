using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AxCrypt
{
    public class Md5StringHash
    {
        public string ComputeHash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] inputHashBytes = md5Hash.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (int index = 0; index < inputHashBytes.Length; ++index)
                {
                    byte b = inputHashBytes[index];
                    sb.Append(b.ToString("x2")); // Hexadecimal.
                }

                return sb.ToString();
            }
        }

        public string GetHash<T>(Stream input) where T : HashAlgorithm, new()
        {
            StringBuilder sb = new StringBuilder();

            using (T hasher = new T())
            {
                byte[] hashBytes = hasher.ComputeHash(input);
                for (int index = 0; index < hashBytes.Length; ++index)
                {
                    byte bt = hashBytes[index];
                    sb.Append(bt.ToString("x2"));
                }
            }

            return sb.ToString();
        }
    }
}
