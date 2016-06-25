using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AxEnum
{
    public static class EnumHelper<T> where T : struct
    {
        public static IEnumerable<T> AsEnumarable()
        {
            return Enum.GetValues(typeof (T)).Cast<T>().AsEnumerable();
        }

        public static IEnumerable<string> GetNames()
        {
            return Enum.GetNames(typeof (T)).AsEnumerable();
        }

        public static string GetName(T value)
        {
            return Enum.GetName(typeof (T), value);
        }


        public static IEnumerable<string> GetDescriptions()
        {
            Type type = typeof (T);
            return Enum.GetValues(type)
                       .Cast<T>()
                       .Select(enumValue => type.GetField(enumValue.ToString()))
                       .Select(fieldInfo => fieldInfo.GetCustomAttributes(typeof (DescriptionAttribute), false).Cast<DescriptionAttribute>())
                       .Select(attribute => attribute.Select(x => x.Description).FirstOrDefault());
        }

        public static string GetDescription(T value)
        {
            Type type = typeof (T);
            return type.GetField(value.ToString())
                       .GetCustomAttributes(typeof (DescriptionAttribute), false)
                       .Cast<DescriptionAttribute>()
                       .Select(attribute => attribute.Description)
                       .FirstOrDefault();
        }

        public static IEnumerable<KeyValuePair<T, string>> GetValuesAndDescriptions()
        {
            Type type = typeof (T);
            return Enum.GetValues(type)
                       .Cast<T>()
                       .Select(enumValue => new KeyValuePair<T, string>(enumValue,
                                                                        type.GetField(enumValue.ToString())
                                                                            .GetCustomAttributes(typeof (DescriptionAttribute), false)
                                                                            .Cast<DescriptionAttribute>()
                                                                            .Select(attribute => attribute.Description)
                                                                            .FirstOrDefault()));
        }

        public static T ParseDescription(string description, bool ignoreCase)
        {
            Type type = typeof (T);
            var found = Enum.GetValues(type)
                            .Cast<T>()
                            .SelectMany(enumValue => type.GetField(enumValue.ToString())
                                                         .GetCustomAttributes(typeof (DescriptionAttribute), false),
                                        (fld, att) => new {Field = fld, Attribute = att})
                            .SingleOrDefault(x => ((DescriptionAttribute) x.Attribute).Description.Equals(description,
                                                                                                          ignoreCase
                                                                                                              ? StringComparison.OrdinalIgnoreCase
                                                                                                              : StringComparison.Ordinal));

            if (found != null)
            {
                return found.Field;
            }

            throw new InvalidEnumArgumentException();
        }

        public static T ParseDescription(string description)
        {
            return ParseDescription(description, false);
        }

        public static bool TryParseDescription(string description, out T result)
        {
            return TryParseDescription(description, false, out result);
        }

        public static bool TryParseDescription(string description, bool ignoreCase, out T result)
        {
            try
            {
                result = ParseDescription(description);
                return true;
            }
            catch
            {
                result = default(T);
                return false;
            }
        }

        public static T ParseName(string name)
        {
            return ParseName(name, false);
        }

        public static T ParseName(string name, bool ignoreCase)
        {
            return (T) Enum.Parse(typeof (T), name, ignoreCase);
        }

        public static bool TryParseName(string name, out T result)
        {
            return TryParseName(name, false, out result);
        }

        public static bool TryParseName(string name, bool ignoreCase, out T result)
        {
            return Enum.TryParse(name, ignoreCase, out result);
        }

        public static bool TryCast(int input, out T result)
        {
            Type type = typeof (T);
            if (Enum.IsDefined(type, input))
            {
                result = (T) Enum.ToObject(type, input);
                return true;
            }
            result = default(T);
            return false;
        }
    }
}