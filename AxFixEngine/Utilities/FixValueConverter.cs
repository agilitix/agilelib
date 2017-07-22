using System;
using QuickFix.Fields.Converters;

namespace AxFixEngine.Utilities
{
    public static class FixValueConverter
    {
        public static T FromString<T>(string fieldValue)
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Boolean:
                    return (T) Convert.ChangeType(BoolConverter.Convert(fieldValue), typeof(T));
                case TypeCode.Char:
                    return (T) Convert.ChangeType(CharConverter.Convert(fieldValue), typeof(T));
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return (T) Convert.ChangeType(IntConverter.Convert(fieldValue), typeof(T));
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return (T) Convert.ChangeType(DecimalConverter.Convert(fieldValue), typeof(T));
                case TypeCode.DateTime:
                    return (T) Convert.ChangeType(DateTimeConverter.ConvertToDateTime(fieldValue), typeof(DateTime));
                case TypeCode.String:
                    return (T) Convert.ChangeType(fieldValue, typeof(T));
                default:
                    throw new ArgumentException();
            }
        }

        public static DateTime FromDateTimeString(string fieldValue)
        {
            return (DateTime) Convert.ChangeType(DateTimeConverter.ConvertToDateTime(fieldValue), typeof(DateTime));
        }

        public static DateTime FromDateString(string fieldValue)
        {
            return (DateTime) Convert.ChangeType(DateTimeConverter.ConvertToDateOnly(fieldValue), typeof(DateTime));
        }

        public static DateTime FromTimeString(string fieldValue)
        {
            return (DateTime) Convert.ChangeType(DateTimeConverter.ConvertToTimeOnly(fieldValue), typeof(DateTime));
        }

        public static string ToString(object fieldValue)
        {
            switch (Type.GetTypeCode(fieldValue.GetType()))
            {
                case TypeCode.Boolean:
                    return BoolConverter.Convert((bool) Convert.ChangeType(fieldValue, typeof(bool)));
                case TypeCode.Char:
                    return CharConverter.Convert((char) Convert.ChangeType(fieldValue, typeof(char)));
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return IntConverter.Convert((long) Convert.ChangeType(fieldValue, typeof(long)));
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return DecimalConverter.Convert((decimal) Convert.ChangeType(fieldValue, typeof(decimal)));
                case TypeCode.DateTime:
                    return DateTimeConverter.Convert((DateTime) Convert.ChangeType(fieldValue, typeof(DateTime)), false);
                case TypeCode.String:
                    return (string) fieldValue;
                default:
                    throw new ArgumentException();
            }
        }

        public static string ToDateString(object fieldValue)
        {
            return DateTimeConverter.ConvertDateOnly((DateTime) Convert.ChangeType(fieldValue, typeof(DateTime)));
        }

        public static string ToTimeString(object fieldValue, bool withMilliseconds = false)
        {
            return DateTimeConverter.ConvertTimeOnly((DateTime) Convert.ChangeType(fieldValue, typeof(DateTime)), withMilliseconds);
        }

        public static string ToDateTimeString(object fieldValue, bool withMilliseconds = false)
        {
            return DateTimeConverter.Convert((DateTime) Convert.ChangeType(fieldValue, typeof(DateTime)), withMilliseconds);
        }
    }
}
