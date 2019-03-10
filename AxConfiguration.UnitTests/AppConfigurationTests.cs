using AxConfiguration.Interfaces;
using AxQuality;
using FluentAssertions;
using NUnit.Framework;

namespace AxConfiguration.UnitTests
{
    internal class AppConfigurationTests : ArrangeActAssert
    {
        protected IAppConfig AppConfigUnderTest;
        protected string ActualKeyValue;
        protected string ExpectedKeyValue;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            ExpectedKeyValue = "keyValue";

            AppConfigUnderTest = new AppConfig(TestDirectory + @"\AppConfiguration\app.main.config");
        }

        public override void Act()
        {
            ActualKeyValue = AppConfigUnderTest.GetKey<string>("keyName");
        }

        [Test]
        public void Assert_expected_keyvalue()
        {
            ActualKeyValue.Should().Be(ExpectedKeyValue);
        }
    }
}
