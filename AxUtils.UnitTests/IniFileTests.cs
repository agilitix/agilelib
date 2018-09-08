using System.Collections.Generic;
using System.Linq;
using AxConfiguration;
using AxConfiguration.Interfaces;
using AxQuality;
using FluentAssertions;
using NUnit.Framework;

namespace AxUtils.UnitTests
{
    internal class IniFileTests : ArrangeActAssert
    {
        protected readonly string TestDirectory = TestContext.CurrentContext.TestDirectory;
        protected IniConfiguration ObjectUnderTests;

        public override void Arrange()
        {
            ObjectUnderTests = new IniConfiguration();
            ObjectUnderTests.LoadConfiguration(TestDirectory + @"\initiator.ini");
        }
    }

    internal class IniFileTests_sections : IniFileTests
    {
        protected IEnumerable<IIniSection> ActualSections;
        protected IDictionary<string, string> ExpectedDefaultSessionDictionary;
        protected IDictionary<string, string> Expected1stSessionDictionary;
        protected IDictionary<string, string> Expected2ndSessionDictionary;

        public override void Arrange()
        {
            base.Arrange();

            ExpectedDefaultSessionDictionary = new Dictionary<string, string>
                                               {
                                                   {"ResetOnLogon", "Y"},
                                                   {"SocketConnectPort", "5001"},
                                                   {"SocketConnectHost", "127.0.0.1"},
                                                   {"DataDictionary", @".\Spec\FIX44.xml"},
                                                   {"UseDataDictionary", "Y"},
                                                   {"EndTime", "00:00:00"},
                                                   {"StartTime", "07:00:00"},
                                                   {"FileLogPath", "fixlog"},
                                                   {"FileStorePath", "store"},
                                                   {"ReconnectInterval", "2"},
                                                   {"ConnectionType", "initiator"},
                                                   {"MessageHistorizationFile", @".\history\messages.log"},
                                               };

            Expected1stSessionDictionary = new Dictionary<string, string>
                                           {
                                               {"BeginString", "FIX.4.2"},
                                               {"SenderCompID", "CLIENT1"},
                                               {"TargetCompID", "EXECUTOR"},
                                               {"HeartBtInt", "25"}
                                           };

            Expected2ndSessionDictionary = new Dictionary<string, string>
                                           {
                                               {"BeginString", "FIX.4.2"},
                                               {"SenderCompID", "CLIENT2"},
                                               {"TargetCompID", "EXECUTOR2"},
                                               {"HeartBtInt", "30"}
                                           };
        }

        public override void Act()
        {
            ActualSections = ObjectUnderTests.Configuration;
        }

        [Test]
        public void Assert_read_expected_number_of_sections()
        {
            ActualSections.Count().Should().Be(3);
        }

        [Test]
        public void Assert_read_three_SESSION_sections()
        {
            ActualSections.Count(x => x.Name == "SESSION").Should().Be(2);
        }

        [Test]
        public void Assert_read_one_DEFAULT_sections()
        {
            ActualSections.Count(x => x.Name == "DEFAULT").Should().Be(1);
        }

        [Test]
        public void Assert_read_DEFAULT_section_has_expected_keys()
        {
            ActualSections.First(x => x.Name == "DEFAULT").Settings.Should().BeEquivalentTo(ExpectedDefaultSessionDictionary);
        }

        [Test]
        public void Assert_read_1st_SESSION_section_has_expected_keys()
        {
            ActualSections.First(x => x.Name == "SESSION").Settings.Should().BeEquivalentTo(Expected1stSessionDictionary);
        }

        [Test]
        public void Assert_read_2nd_SESSION_section_has_expected_keys()
        {
            ActualSections.Where(x => x.Name == "SESSION").ElementAt(1).Settings.Should().BeEquivalentTo(Expected2ndSessionDictionary);
        }
    }
}
