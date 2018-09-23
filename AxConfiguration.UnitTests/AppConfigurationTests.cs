using AxConfiguration.Interfaces;
using AxQuality;
using FluentAssertions;
using NUnit.Framework;

namespace AxConfiguration.UnitTests
{
    internal class AppConfigurationTests : ArrangeActAssert
    {
        protected IAppConfiguration AppConfigurationUnderTest;
        protected string ActualKeyValue;
        protected string ExpectedKeyValue;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            ExpectedKeyValue = "keyValue";

            AppConfigurationUnderTest = new AppConfiguration();
            AppConfigurationUnderTest.LoadConfiguration(TestDirectory + @"\AppConfiguration\app.main.config");
        }

        public override void Act()
        {
            ActualKeyValue = AppConfigurationUnderTest.Configuration.AppSettings.Settings["keyName"].Value;
        }

        [Test]
        public void Assert_expected_keyvalue()
        {
            ActualKeyValue.Should().Be(ExpectedKeyValue);
        }
    }
}
