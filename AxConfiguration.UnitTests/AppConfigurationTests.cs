using AxConfiguration.Interfaces;
using AxQuality;
using FluentAssertions;
using NUnit.Framework;

namespace AxConfiguration.UnitTests
{
    internal class AppConfigurationTests : ArrangeActAssert
    {
        protected IConfigurationFileProvider ConfigurationFileProvider;
        protected IAppConfiguration AppConfigurationUnderTest;
        protected string ActualKeyValue;
        protected string ExpectedKeyValue;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            ExpectedKeyValue = "keyValue";

            ConfigurationFileProvider = new ConfigurationFileProvider(TestDirectory + @"\MainConfiguration");
            AppConfigurationUnderTest = new AppConfiguration();
            AppConfigurationUnderTest.LoadFile(ConfigurationFileProvider.AppConfigFile);
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
