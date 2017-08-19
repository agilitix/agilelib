using System;
using System.Collections.Generic;
using System.Linq;
using AxFixEngine.Extensions;
using AxQuality;
using FluentAssertions;
using NUnit.Framework;
using QuickFix;

namespace AxFixEngine.UnitTests
{
    internal class DictionaryExtensionsTests : ArrangeActAssert
    {
        protected readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;
        protected Dictionary ObjectUnderTest;
        protected IList<KeyValuePair<string, string>> ExpectedDictionaryContent;

        public override void Arrange()
        {
            ExpectedDictionaryContent = new List<KeyValuePair<string, string>>
                                {
                                    new KeyValuePair<string, string>("NAME", "NameOfSomething"),
                                    new KeyValuePair<string, string>("KEY", "value"),
                                    new KeyValuePair<string, string>("TIME", "08:00:00"),
                                };

            ObjectUnderTest = new Dictionary();
            foreach (var content in new List<KeyValuePair<string, string>>
                                    {
                                        new KeyValuePair<string, string>("NamE", "NameOfSomething"),
                                        new KeyValuePair<string, string>("KEY", "value"),
                                        new KeyValuePair<string, string>("Time", "08:00:00"),
                                    })
            {
                ObjectUnderTest.SetString(content.Key, content.Value);
            }
        }
    }

    internal class DictionaryExtensionsTests_dictionary_as_enumerable : DictionaryExtensionsTests
    {
        protected IList<KeyValuePair<string, string>> ActualDictionaryContent;

        public override void Act()
        {
            ActualDictionaryContent = ObjectUnderTest.AsEnumerable().ToList();
        }

        [Test]
        public void Assert_dictionary_content_as_enumarable()
        {
            var merge = ExpectedDictionaryContent.Zip(ActualDictionaryContent, (a, e) => new {Actual = a, Expected = e}).ToList();
            merge.Count.Should().Be(ExpectedDictionaryContent.Count);
            foreach (var m in merge)
            {
                m.Actual.Key.Should().Be(m.Expected.Key);
                m.Actual.Value.Should().Be(m.Expected.Value);
            }
        }
    }

    internal class DictionaryExtensionsTests_dictionary_get_time_parameter : DictionaryExtensionsTests
    {
        protected DateTime ActualDateTimeLowerCase;
        protected DateTime ActualDateTimeUpperCase;
        protected DateTime ExpectedDateTime;

        public override void Arrange()
        {
            base.Arrange();
            ExpectedDateTime = DateTime.Parse("1980-01-01T08:00:00");
        }

        public override void Act()
        {
            ActualDateTimeLowerCase = ObjectUnderTest.GetTime("time");
            ActualDateTimeUpperCase = ObjectUnderTest.GetTime("TIME");
        }

        [Test]
        public void Assert_get_time_from_dictionary()
        {
            ActualDateTimeLowerCase.Should().Be(ExpectedDateTime);
            ActualDateTimeUpperCase.Should().Be(ExpectedDateTime);
        }
    }

    internal class DictionaryExtensionsTests_dictionary_get_unknown_setting : DictionaryExtensionsTests
    {
        protected Exception ActualException;

        public override void Act()
        {
            ActualException = Trying(() => ObjectUnderTest.GetString("N/A"));
        }

        [Test]
        public void Assert_config_error_exception()
        {
            ActualException.Should().BeOfType<ConfigError>();
        }
    }
}
