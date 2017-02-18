using AxConfiguration.Interfaces;
using AxQuality;
using NFluent;
using NUnit.Framework;

namespace AxConfiguration.UnitTests
{
    public class ConfigurationProviderTests : ArrangeActAssert
    {
        protected IConfigurationProvider ConfigurationProviderUnderTest;
        protected string ActualKeyValue;
        protected string ExpectedKeyValue;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            ExpectedKeyValue = "keyValue";
            ConfigurationProviderUnderTest = new ConfigurationProvider();
        }

        public override void Act()
        {
            ConfigurationProviderUnderTest.LoadDefaultConfigurationFile(TestDirectory + @"\MainConfiguration");
            ActualKeyValue = ConfigurationProviderUnderTest.Configuration.AppSettings.Settings["keyName"].Value;
        }

        [Test]
        public void Assert_expected_keyvalue()
        {
            Check.That(ActualKeyValue).IsEqualTo(ExpectedKeyValue);
        }
    }
}
