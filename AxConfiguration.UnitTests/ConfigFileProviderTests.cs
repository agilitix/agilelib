using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using NUnit.Framework;

namespace AxConfiguration.UnitTests
{
    [TestFixture]
    internal class ConfigFileProviderTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            /* Little hack to setup the GetEntryAssembly which is null otherwise in NUnit tests */
            //Assembly assembly = Assembly.GetExecutingAssembly();

            //AppDomainManager manager = new AppDomainManager();
            //FieldInfo entryAssemblyfield = manager.GetType().GetField("m_entryAssembly", BindingFlags.Instance | BindingFlags.NonPublic);
            //entryAssemblyfield.SetValue(manager, assembly);

            //AppDomain domain = AppDomain.CurrentDomain;
            //FieldInfo domainManagerField = domain.GetType().GetField("_domainManager", BindingFlags.Instance | BindingFlags.NonPublic);
            //domainManagerField.SetValue(domain, manager);
            /* end of GetEntryAssembly hack */

            // Create a fake user level config file.
            File.Copy(Path.Combine(TestContext.CurrentContext.TestDirectory, $@".\ConfigProvider2\unity.config"),
                      Path.Combine(TestContext.CurrentContext.TestDirectory, $@".\ConfigProvider2\unity.user.{Environment.UserName.ToLower()}.config"),
                      true);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            // Remove the fake user level config file.
            string userFile = Path.Combine(TestContext.CurrentContext.TestDirectory, $@".\ConfigProvider2\unity.user.{Environment.UserName.ToLower()}.config");
            if (File.Exists(userFile))
            {
                File.Delete(userFile);
            }
        }

        private static IEnumerable<TestCaseData> _configs = new List<TestCaseData>
        {
            new TestCaseData(@".\ConfigProvider1", @".\ConfigProvider1\unity.host." + Dns.GetHostName().ToLower() + ".config"),
            new TestCaseData(@".\ConfigProvider2", @".\ConfigProvider2\unity.user." + Environment.UserName.ToLower() + ".config"),
            new TestCaseData(@".\ConfigProvider3", @".\ConfigProvider3\unity.config"),
        };

        [Test]
        [TestCaseSource(nameof(_configs))]
        public void Given_a_folder_Should_find_a_config_file(string configFolder, string expectedConfigFile)
        {
            /*
             * Arrange.
             */
            string folder = Path.Combine(TestContext.CurrentContext.TestDirectory, configFolder);
            ConfigFileProvider configFileProvider = new ConfigFileProvider(folder);

            /*
             * Act.
             */
            // The config file will be choose from Host level to the default level (host level => user level => default level).
            string actualConfigFile = configFileProvider.GetConfigFile("unity");

            /*
             * Assert.
             */
            string expectedFile = Path.Combine(TestContext.CurrentContext.TestDirectory, string.Format(expectedConfigFile, Environment.UserName.ToLower()));

            Assert.That(actualConfigFile, Is.EqualTo(expectedFile));
        }
    }
}
