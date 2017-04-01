using System.IO;
using AxQuality;
using NUnit.Framework;

namespace AxCrypt.UnitTests
{
    internal class AesStringEncryptionUnitTests : ArrangeActAssert
    {
        protected string OriginalString;
        protected string EncryptedString;
        protected string DecryptedString;

        protected AesStringEncryption ObjectUnderTest;

        public override void Arrange()
        {
            OriginalString =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            ObjectUnderTest = new AesStringEncryption();
        }

        public override void Act()
        {
            EncryptedString = ObjectUnderTest.Encrypt(OriginalString, "p@ssw0rd");
            DecryptedString = ObjectUnderTest.Decrypt(EncryptedString, "p@ssw0rd");
        }

        [Test]
        public void Assert_decrypted_string_is_same_as_original_string()
        {
            Assert.AreEqual(DecryptedString, OriginalString);
        }
    }
}