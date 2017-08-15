using System;

namespace AxFixEngine.Utilities
{
    public static class DayOfWeekConverter
    {
        public static string ToString(DayOfWeek dayOfWeek)
        {
            return dayOfWeek.ToString().Substring(0, 2).ToUpper();
        }

        public static DayOfWeek FromString(string dayOfWeek)
        {
            switch (dayOfWeek.Substring(0, 2).ToUpper())
            {
                case "MO":
                    return DayOfWeek.Monday;
                case "TU":
                    return DayOfWeek.Tuesday;
                case "WE":
                    return DayOfWeek.Wednesday;
                case "TH":
                    return DayOfWeek.Thursday;
                case "FR":
                    return DayOfWeek.Friday;
                case "SA":
                    return DayOfWeek.Saturday;
                case "SU":
                    return DayOfWeek.Sunday;
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}
