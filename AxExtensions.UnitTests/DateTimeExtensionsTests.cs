using System;
using System.Collections.Generic;
using System.Linq;
using AxQuality;
using NUnit.Framework;

namespace AxExtensions.UnitTests
{
    public class DateTimeExtensionsTests : ArrangeActAssert
    {
        protected IList<DateTime> StartDatesUnderTests;
        protected IList<DateTime> EndDates;

        protected IList<DateTimeAge> ResultAges;
        protected IList<DateTimeAge> ExpectedAges;

        public override void Arrange()
        {
            StartDatesUnderTests = new List<DateTime>
                                   {
                                       new DateTime(1963, 12, 25),
                                       new DateTime(1986, 2, 15),
                                       new DateTime(2000, 12, 28)
                                   };
            EndDates = new List<DateTime>
                       {
                           new DateTime(2016, 8, 20),
                           new DateTime(2015, 9, 2),
                           new DateTime(2009, 9, 15)
                       };

            ResultAges = new List<DateTimeAge>();

            // http://www.calculator.net/
            ExpectedAges = new List<DateTimeAge>
                           {
                               new DateTimeAge {Years = 52, Months = 7, Days = 26},
                               new DateTimeAge {Years = 29, Months = 6, Days = 18},
                               new DateTimeAge {Years = 8, Months = 8, Days = 18}
                           };
        }

        public override void Act()
        {
            StartDatesUnderTests.Zip(EndDates, (start, end) => new {StartDate = start, EndDate = end})
                                .ForEach(x => ResultAges.Add(x.StartDate.AgeTo(x.EndDate)));
        }

        [Test]
        public void Assert_expected_ages_are_meet()
        {
            Assert.IsTrue(ResultAges.SequenceEqual(ExpectedAges));
        }
    }
}