using AxConfiguration.Interfaces;
using AxQuality;
using NUnit.Framework;

namespace AxConfiguration.UnitTests
{
    public class ConfigurationProviderTests : ArrangeActAssert
    {
        protected IConfigurationProvider ConfigurationProviderUnderTest;
        protected string ActualKeyValue;
        protected string ExpectedKey;

        public override void Arrange()
        {
            ExpectedKey = "keyValue";
            ConfigurationProviderUnderTest = new ConfigurationProvider(@".\MainConfiguration");
        }

        public override void Act()
        {
            ActualKeyValue = ConfigurationProviderUnderTest.Configuration.AppSettings.Settings["keyName"].Value;
        }

        [Test]
        public void Assert_expected_keyvalue()
        {
            Assert.AreEqual(ActualKeyValue, ExpectedKey);
        }
    }
}
