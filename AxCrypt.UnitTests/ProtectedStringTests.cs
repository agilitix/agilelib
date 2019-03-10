using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AxCrypt.UnitTests
{
    [TestFixture]
    internal class ProtectedStringTests
    {
        [Test]
        public void Given_readable_string_Should_encrypt_and_decrypt_back_for_same_user()
        {
            /*
             * Arrange.
             */
            string textToProtect = $"Assuming the user {Environment.UserName} has encrypted this text, only this user can decrypt and see this text again";

            /*
             * Act.
             */
            ProtectedString ps = new ProtectedString();
            string crypted = ps.Protect(textToProtect);
            string uncrypted = ps.Unprotect(crypted);

            /*
             * Assert.
             */
            Assert.That(crypted, Is.Not.EqualTo(textToProtect));
            Assert.That(uncrypted, Is.EqualTo(textToProtect));
        }
    }
}
