﻿using System;
using System.IO;
using System.Security.Cryptography;

namespace AxCrypt
{
    public class AesStringEncryption
    {
        // Recommended is >= 1000
        protected readonly int Iterations = 1024;

        #region Salt bytes

        // 8 bytes at least.
        protected readonly byte[] Salt =
        {
            0xd8,
            0xcc,
            0x37,
            0x96,
            0xb0,
            0xd7,
            0x56,
            0x75,
            0x91,
            0x73,
            0x02,
            0x60,
            0xcc,
            0xc1,
            0xcf,
            0xa6,
            0xf9,
            0x75,
            0xd0,
            0xec,
            0x9a,
            0xe7,
            0x5e,
            0xfe,
            0x4f,
            0x04,
            0xbc,
            0x73,
            0xa7,
            0x00,
            0xc3,
            0x32,
            0x61,
            0x15,
            0xd7,
            0xcd,
            0x95,
            0x37,
            0x32,
            0x3a,
            0xbb,
            0x7c,
            0xb6,
            0x5f,
            0x92,
            0xf3,
            0xd9,
            0x06,
            0x47,
            0xb5,
            0xfa,
            0xfb,
            0x9d,
            0x8d,
            0xdb,
            0xa2,
            0xf3,
            0xb5,
            0x32,
            0x9b,
            0x7e,
            0xbd,
            0xc1,
            0x52
        };

        #endregion

        public string Encrypt(string input, string password)
        {
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, Salt, Iterations);

            var aes = new RijndaelManaged();
            aes.KeySize = aes.LegalKeySizes[0].MaxSize;
            aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.ISO10126;

            ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream output = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(output, transform, CryptoStreamMode.Write))
                using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                {
                    streamWriter.Write(input);
                }

                return Convert.ToBase64String(output.ToArray());
            }
        }

        public string Decrypt(string input, string password)
        {
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, Salt, Iterations);

            var aes = new RijndaelManaged();
            aes.KeySize = aes.LegalKeySizes[0].MaxSize;
            aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.ISO10126;

            ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(input)))
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
            using (StreamReader streamReader = new StreamReader(cryptoStream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
