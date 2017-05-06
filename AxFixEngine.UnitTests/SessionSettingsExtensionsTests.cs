using System;
using AxFixEngine.Extensions;
using AxQuality;
using FluentAssertions;
using NUnit.Framework;
using QuickFix;

namespace AxFixEngine.UnitTests
{
    internal class SessionSettingsExtensionsTests : ArrangeActAssert
    {
        protected SessionSettings ObjectUnderTest;
    }

    internal class SessionSettingsExtensionsTests_vanilla_types : SessionSettingsExtensionsTests
    {
        protected string ExpectedValueString;
        protected string ActualValueString;

        protected int ExpectedValueInt;
        protected int ActualValueInt;

        protected long ExpectedValueLong;
        protected long ActualValueLong;

        protected double ExpectedValueDouble;
        protected double ActualValueDouble;

        protected DateTime ExpectedValueDateTime;
        protected DateTime ActualValueDateTime;

        protected bool ExpectedValueBool;
        protected bool ActualValueBool;

        protected DayOfWeek ExpectedValueDayOfWeek;
        protected DayOfWeek ActualValueDayOfWeek;

        protected string ExpectedDefaultValueString;
        protected string ActualDefaultValueString;

        public override void Arrange()
        {
            ExpectedValueString = "2500";
            ExpectedValueInt = 2500;
            ExpectedValueLong = 2500;
            ExpectedValueDouble = 2500.0D;
            ExpectedValueDateTime = DateTime.Parse("05:59:00");
            ExpectedValueBool = true;
            ExpectedValueDayOfWeek = DayOfWeek.Friday;
            ExpectedDefaultValueString = "initiator";

            ObjectUnderTest = SessionSettingsTestsProvider.GetSessionSettings1();
        }

        public override void Act()
        {
            ActualValueString = ObjectUnderTest.GetSetting<string>(new SessionID("FIX.4.2",
                                                                                             "Company",
                                                                                             "FixedIncome",
                                                                                             "HongKong",
                                                                                             "CLIENT1",
                                                                                             "HedgeFund",
                                                                                             "NYC"),
                                                                               "MaxMessagesInResendRequest");

            ActualValueInt = ObjectUnderTest.GetSetting<int>(new SessionID("FIX.4.2",
                                                                                       "Company",
                                                                                       "FixedIncome",
                                                                                       "HongKong",
                                                                                       "CLIENT1",
                                                                                       "HedgeFund",
                                                                                       "NYC"),
                                                                         "MaxMessagesInResendRequest");

            ActualValueLong = ObjectUnderTest.GetSetting<long>(new SessionID("FIX.4.2",
                                                                                         "Company",
                                                                                         "FixedIncome",
                                                                                         "HongKong",
                                                                                         "CLIENT1",
                                                                                         "HedgeFund",
                                                                                         "NYC"),
                                                                           "MaxMessagesInResendRequest");

            ActualValueDouble = ObjectUnderTest.GetSetting<double>(new SessionID("FIX.4.2",
                                                                                             "Company",
                                                                                             "FixedIncome",
                                                                                             "HongKong",
                                                                                             "CLIENT1",
                                                                                             "HedgeFund",
                                                                                             "NYC"),
                                                                               "MaxMessagesInResendRequest");

            ActualValueDateTime = ObjectUnderTest.GetSetting<DateTime>(new SessionID("FIX.4.2",
                                                                                                 "Company",
                                                                                                 "FixedIncome",
                                                                                                 "HongKong",
                                                                                                 "CLIENT1",
                                                                                                 "HedgeFund",
                                                                                                 "NYC"),
                                                                                   "EndTime");

            ActualValueBool = ObjectUnderTest.GetSetting<bool>(new SessionID("FIX.4.2",
                                                                                         "Company",
                                                                                         "FixedIncome",
                                                                                         "HongKong",
                                                                                         "CLIENT1",
                                                                                         "HedgeFund",
                                                                                         "NYC"),
                                                                           "MillisecondsInTimeStamp");

            ActualValueDayOfWeek = ObjectUnderTest.GetSetting<DayOfWeek>(new SessionID("FIX.4.2",
                                                                                                   "Company",
                                                                                                   "FixedIncome",
                                                                                                   "HongKong",
                                                                                                   "CLIENT1",
                                                                                                   "HedgeFund",
                                                                                                   "NYC"),
                                                                                     "EndDay");

            ActualDefaultValueString = ObjectUnderTest.GetSetting<string>(new SessionID("FIX.4.2",
                                                                                                    "Company",
                                                                                                    "FixedIncome",
                                                                                                    "HongKong",
                                                                                                    "CLIENT1",
                                                                                                    "HedgeFund",
                                                                                                    "NYC"),
                                                                                      "ConnectionType");
        }

        [Test]
        public void Assert_string_value()
        {
            ActualValueString.Should().Be(ExpectedValueString);
        }

        [Test]
        public void Assert_default_string_value()
        {
            ActualDefaultValueString.Should().Be(ExpectedDefaultValueString);
        }

        [Test]
        public void Assert_int_value()
        {
            ActualValueInt.Should().Be(ExpectedValueInt);
        }

        [Test]
        public void Assert_long_value()
        {
            ActualValueLong.Should().Be(ExpectedValueLong);
        }

        [Test]
        public void Assert_double_value()
        {
            ActualValueDouble.Should().Be(ExpectedValueDouble);
        }

        [Test]
        public void Assert_date_time_value()
        {
            ActualValueDateTime.Should().Be(ExpectedValueDateTime);
        }

        [Test]
        public void Assert_bool_value()
        {
            ActualValueBool.Should().Be(ExpectedValueBool);
        }

        [Test]
        public void Assert_day_of_week_value()
        {
            ActualValueDayOfWeek.Should().Be(ExpectedValueDayOfWeek);
        }
    }
}
