using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AxFixEngine.Extensions;
using AxQuality;
using FluentAssertions;
using NUnit.Framework;
using QuickFix.DataDictionary;

namespace AxFixEngine.UnitTests
{
    internal class DataDictionaryExtensionsTests : ArrangeActAssert
    {
        protected readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;
        protected DataDictionary ObjectUnderTest;

        public override void Arrange()
        {
            ObjectUnderTest = new DataDictionary();
            ObjectUnderTest.Load(TestDirectory + ".\\Spec\\FIX44.xml");
        }
    }

    internal class DataDictionaryExtensionsTests_dictionary_description : DataDictionaryExtensionsTests
    {
        protected string ExpectedDescription;
        protected string ActualDescription;

        public override void Arrange()
        {
            base.Arrange();

            ExpectedDescription = "Version=FIX.4.4, MajorVersion=4, MinorVersion=4, MessagesCount=92, TagsCount=916, CheckFieldsHaveValues=True, CheckFieldsOutOfOrder=True, CheckUserDefinedFields=True";
        }

        public override void Act()
        {
            ActualDescription = ObjectUnderTest.GetDescription();
        }

        [Test]
        public void Assert_DataDictionary_description_is_working()
        {
            ActualDescription.Should().Be(ExpectedDescription);
        }
    }
}
