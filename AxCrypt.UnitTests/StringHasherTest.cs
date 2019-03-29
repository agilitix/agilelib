using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AxCrypt.UnitTests
{
    [TestFixture]
    internal class StringHasherTest
    {
        [Test]
        public void Given_text_Should_be_hash_to_md5()
        {
            /*
             * Arrange.
             */
            string text = "the text";
            string md5 = "9d54f4c0c77def4be7880a85991b04c5";

            /*
             * Act.
             */
            StringHasher hasher = new StringHasher(MD5.Create);
            string hash = hasher.ComputeHash(text);

            /*
             * Assert.
             */
            hash.Should().Be(md5);
        }
    }
}
