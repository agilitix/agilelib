using AxConfiguration.Interfaces;
using AxQuality;
using NFluent;
using NUnit.Framework;

namespace AxConfiguration.UnitTests
{
    public class AppConfigurationTests : ArrangeActAssert
    {
        protected IAppConfiguration AppConfigurationUnderTest;
        protected string ActualKeyValue;
        protected string ExpectedKeyValue;
        private readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;

        public override void Arrange()
        {
            ExpectedKeyValue = "keyValue";

            AppConfigurationUnderTest = new AppConfiguration();
            AppConfigurationUnderTest.LoadDefaultFile(TestDirectory + @"\MainConfiguration");
        }

        public override void Act()
        {
            ActualKeyValue = AppConfigurationUnderTest.Configuration.AppSettings.Settings["keyName"].Value;
        }

        [Test]
        public void Assert_expected_keyvalue()
        {
            Check.That(ActualKeyValue).IsEqualTo(ExpectedKeyValue);
        }
    }
}
