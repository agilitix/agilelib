using System;

namespace AxExtensions
{
    public struct DateTimeAge
    {
        public int Years;
        public int Months;
        public int Days;
    }

    public static class DateTimeExtensions
    {
        public static int CalculateYearsTo(this DateTime self, DateTime other)
        {
            DateTimeAge age = self.CalculateAgeTo(other);
            return age.Years;
        }

        public static int CalculateMonthsTo(this DateTime self, DateTime other)
        {
            DateTimeAge age = self.CalculateAgeTo(other);
            return age.Years * 12 + age.Months;
        }

        public static int CalculateDaysTo(this DateTime self, DateTime other)
        {
            DateTime start, end;
            if (self < other)
            {
                start = self;
                end = other;
            }
            else
            {
                start = other;
                end = self;
            }

            return (int)end.Subtract(start).TotalDays;
        }

        public static DateTimeAge CalculateAgeTo(this DateTime self, DateTime other)
        {
            DateTime start, end;
            if (self < other)
            {
                start = self;
                end = other;
            }
            else
            {
                start = other;
                end = self;
            }

            DateTimeOffset minOffset = DateTimeOffset.MinValue;
            DateTimeOffset offset = minOffset.AddDays(end.Subtract(start).TotalDays);

            return new DateTimeAge
            {
                Years = offset.Year - minOffset.Year,
                Months = offset.Month - minOffset.Month,
                Days = offset.Day - minOffset.Day
            };
        }
    }
}
