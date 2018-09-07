using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AxExtensions
{
    public static class HashExtensions
    {
        public static string GetHash<T>(this Stream self) where T : HashAlgorithm, new()
        {
            StringBuilder sb = new StringBuilder();

            using (T hasher = new T())
            {
                byte[] hashBytes = hasher.ComputeHash(self);
                for (var index = 0; index < hashBytes.Length; ++index)
                {
                    byte bt = hashBytes[index];
                    sb.Append(bt.ToString("x2"));
                }
            }

            return sb.ToString();
        }
    }
}
