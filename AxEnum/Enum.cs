using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace AxEnum
{
    public static class Enum<T> where T : struct
    {
        public static IEnumerable<T> AsEnumarable()
        {
            return Enum.GetValues(typeof (T)).Cast<T>().AsEnumerable();
        }

        public static IEnumerable<string> GetNames()
        {
            return Enum.GetNames(typeof (T)).AsEnumerable();
        }

        public static IEnumerable<string> GetDescriptions()
        {
            IEnumerable<T> enumValues = AsEnumarable();

            IEnumerable<string> result = enumValues.Select(x =>
            {
                FieldInfo fieldInfo = typeof(T).GetField(x.ToString());
                string description = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                                              .Cast<DescriptionAttribute>()
                                              .Select(attribute => attribute.Description)
                                              .FirstOrDefault();
                return description;
            });
            return result;
        }

        public static string GetDescription(T value)
        {
            FieldInfo fieldInfo = typeof (T).GetField(value.ToString());
            string result = fieldInfo.GetCustomAttributes(typeof (DescriptionAttribute), false)
                                     .Cast<DescriptionAttribute>()
                                     .Select(attribute => attribute.Description)
                                     .FirstOrDefault();
            return result;
        }


        public static IEnumerable<KeyValuePair<T, string>> GetValuesAndDescriptions()
        {
            IEnumerable<T> enumValues = AsEnumarable();

            var result = enumValues.Select(x =>
                                           {
                                               FieldInfo fieldInfo = typeof (T).GetField(x.ToString());
                                               string description = fieldInfo.GetCustomAttributes(typeof (DescriptionAttribute), false)
                                                                             .Cast<DescriptionAttribute>()
                                                                             .Select(attribute => attribute.Description)
                                                                             .FirstOrDefault();
                                               return new KeyValuePair<T, string>(x, description);
                                           });
            return result;
        }

        // TODO: [try]parse description

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
            foreach (var enumValue in Enum.GetValues(typeof (T)))
            {
                if (input == (int) enumValue)
                {
                    result = (T) enumValue;
                    return true;
                }
            }
            result = default(T);
            return false;
        }
    }
}