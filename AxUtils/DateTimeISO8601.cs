using System;

namespace AxUtils
{
    public static class DateTimeISO8601
    {
        private static readonly int _lenUnsKind = "2017-09-19T15:16:11.6008521".Length;
        private static readonly int _lenUtcKind = "2017-09-19T13:15:48.8446795Z".Length;
        private static readonly int _lenLocKind = "2017-09-19T15:16:11.6008521+02:00".Length;

        public static string ToString(DateTime input)
        {
            return input.ToString("o");
        }

        public static string ToString(DateTimeOffset input)
        {
            return input.ToString("o");
        }

        public static DateTime ParseDateTime(string input)
        {
            return ToDateTime(input);
        }

        public static DateTimeOffset ParseDateTimeOffset(string input)
        {
            return ToDateTimeOffset(input);
        }

        private static DateTimeOffset ToDateTimeOffset(string dateTime)
        {
            DateTimeOffset dto = DateTimeOffset.Parse(dateTime);
            return dto;
        }

        private static DateTime ToDateTime(string dateTime)
        {
            DateTimeOffset dto = DateTimeOffset.Parse(dateTime);
            if (dateTime.Length == _lenLocKind) // Local kind
                return dto.LocalDateTime;
            if (dateTime.Length == _lenUtcKind) // Utc kind
                return dto.UtcDateTime;
            if (dateTime.Length == _lenUnsKind) // Unspecified kind
                return dto.DateTime;

            throw new InvalidOperationException("Invalid date time string");
        }
    }
}
