using System;

namespace AxExtensions
{
    public struct DateTimeAge
    {
        public int Years;
        public int Months;
        public int Days;
        public int Hours;
        public int Minutes;
        public int Seconds;

        public override string ToString()
        {
            return string.Format("{0}Y {1}m {2}D {3}H {4}M {5}S", Years, Months, Days, Hours, Minutes, Seconds);
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

        public static int HoursTo(this DateTime self, DateTime end)
        {
            return DaysTo(self, end)*24;
        }

        public static int MinutesTo(this DateTime self, DateTime end)
        {
            return HoursTo(self, end)*60;
        }

        public static int SecondsTo(this DateTime self, DateTime end)
        {
            return HoursTo(self, end)*3600;
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
                       Days = days,
                       Hours = hours,
                       Minutes = minutes,
                       Seconds = seconds
                   };
        }
    }
}