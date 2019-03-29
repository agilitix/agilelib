﻿using System;
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
        private static object[] TestCases =
        {
            new object[] {"the text", "9d54f4c0c77def4be7880a85991b04c5", new Func<HashAlgorithm>(MD5.Create)},
            new object[] {"the text", "a8f3b04d39cb88ae67c6046a0c24b71bd14c68e0", new Func<HashAlgorithm>(SHA1.Create)},
            new object[] {"the text", "41a1f654dc79a9ac645afa553c31d51fd115eca8dd1cb9e6c67ae03e52718e8b", new Func<HashAlgorithm>(SHA256.Create)},
            new object[] {"the text", "d145fc5b83a1ae022c5c3781a0bdb61e9b182f5084cdf57b53094cef57df780d3121288802cf1c3410c80ed112c26b305700300226b1062e37bfef868e3e28ba", new Func<HashAlgorithm>(SHA512.Create)},
        };

        [TestCaseSource(nameof(TestCases))]
        public void Given_text_Should_be_hash(string text, string expectedHash, Func<HashAlgorithm> hasher)
        {
            /*
             * Arrange.
             */

            /*
             * Act.
             */
            StringHasher stringHasher = new StringHasher(hasher);
            string actualHash = stringHasher.ComputeHash(text);

            /*
             * Assert.
             */
            actualHash.Should().Be(expectedHash);
        }
    }
}
