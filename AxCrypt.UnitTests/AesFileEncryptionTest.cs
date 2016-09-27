using System.IO;
using AxQuality;
using NUnit.Framework;

namespace AxCrypt.UnitTests
{

    public class AesFileEncryptionUnitTests : ArrangeActAssert
    {
        protected string OriginalFile = "LoremIpsum.txt";
        protected string EncryptedFile = "LoremIpsum.encrypted.txt";
        protected string DecryptedFile = "LoremIpsum.decrypted.txt";

        protected AesFileEncryption ObjectUnderTest;

        public override void Startup()
        {
            RemoveTestFiles();
        }

        public override void Arrange()
        {
            ObjectUnderTest = new AesFileEncryption();
        }

        public override void Act()
        {
            File.WriteAllText(OriginalFile,
                              "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");

            ObjectUnderTest.EncryptFile(OriginalFile, EncryptedFile, "p@ssw0rd");
            ObjectUnderTest.DecryptFile(EncryptedFile, DecryptedFile, "p@ssw0rd");
        }

        public override void Cleanup()
        {
            RemoveTestFiles();
        }

        [Test]
        public void Assert_decrypted_file_is_same_as_original_file()
        {
            Assert.IsTrue(FilesAreEqual(DecryptedFile, OriginalFile));
        }

        [Test]
        public void Assert_encrypted_file_is_not_same_as_original_file()
        {
            Assert.IsFalse(FilesAreEqual(EncryptedFile, OriginalFile));
        }

        public void RemoveTestFiles()
        {
            if (File.Exists(OriginalFile))
            {
                File.Delete(OriginalFile);
            }
            if (File.Exists(EncryptedFile))
            {
                File.Delete(EncryptedFile);
            }
            if (File.Exists(DecryptedFile))
            {
                File.Delete(DecryptedFile);
            }
        }

        /// <summary>
        /// Little helper class to check if files are equal.
        /// </summary>
        protected bool FilesAreEqual(string path1, string path2)
        {
            byte[] file1 = File.ReadAllBytes(path1);
            byte[] file2 = File.ReadAllBytes(path2);
            if (file1.Length == file2.Length)
            {
                for (int i = 0; i < file1.Length; i++)
                {
                    if (file1[i] != file2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}