using System;

namespace AxExtensions
{
    public struct DateTimeAge
    {
        public int Years;
        public int Months;
        public int Weeks;
        public int Days;
        public int Hours;
        public int Minutes;
        public int Seconds;

        public override string ToString()
        {
            return string.Format("{0}Y {1}m {2}W {3}D {4}H {5}M {6}S", Years, Months, Weeks, Days, Hours, Minutes, Seconds);
        }
    }

    public static class DateTimeExtensions
    {
        public static int YearsTo(this DateTime self, DateTime end)
        {
            DateTimeAge age = self.AgeTo(end);
            return age.Years;
        }

        public static int MonthsTo(this DateTime self, DateTime end)
        {
            DateTimeAge age = self.AgeTo(end);
            return age.Years*12 + age.Months;
        }

        public static int DaysTo(this DateTime self, DateTime end)
        {
            DateTime first, last;
            if (self < end)
            {
                first = self;
                last = end;
            }
            else
            {
                first = end;
                last = self;
            }

            return (int) last.Subtract(first).TotalDays;
        }

        public static int WeeksTo(this DateTime self, DateTime end)
        {
            return DaysTo(self, end)/7;
        }

        public static int HoursTo(this DateTime self, DateTime end)
        {
            return DaysTo(self, end)*24;
        }

        public static int MinutesTo(this DateTime self, DateTime end)
        {
            return DaysTo(self, end)*24*60;
        }

        public static int SecondsTo(this DateTime self, DateTime end)
        {
            return DaysTo(self, end)*24*60*60;
        }

        public static DateTimeAge AgeTo(this DateTime self, DateTime end)
        {
            DateTime first, last;
            if (self < end)
            {
                first = self;
                last = end;
            }
            else
            {
                first = end;
                last = self;
            }

            int seconds = last.Second - first.Second;
            if (seconds < 0)
            {
                last = last.AddMinutes(-1);
                seconds += 60;
            }

            int minutes = last.Minute - first.Minute;
            if (minutes < 0)
            {
                last = last.AddHours(-1);
                minutes += 60;
            }

            int hours = last.Hour - first.Hour;
            if (hours < 0)
            {
                last = last.AddDays(-1);
                hours += 24;
            }

            int days = last.Day - first.Day;
            if (days < 0)
            {
                last = last.AddMonths(-1);
                days += DateTime.DaysInMonth(last.Year, last.Month);
            }

            int weeks = days/7;
            days %= 7;

            int months = last.Month - first.Month;
            if (months < 0)
            {
                last = last.AddYears(-1);
                months += 12;
            }

            int years = last.Year - first.Year;

            return new DateTimeAge
                   {
                       Years = years,
                       Months = months,
                       Weeks = weeks,
                       Days = days,
                       Hours = hours,
                       Minutes = minutes,
                       Seconds = seconds
                   };
        }
    }
}