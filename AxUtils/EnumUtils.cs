using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AxUtils
{
    public class EnumInfos<T> where T : struct
    {
        public T Value;
        public string Name;
        public string Description;
    }

    public static class EnumUtils<T> where T : struct
    {
        private static readonly IDictionary<T, EnumInfos<T>> _valueToInfos;
        private static readonly IDictionary<string, EnumInfos<T>> _descriptionToInfos;

        static EnumUtils()
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new NotSupportedException();
            }

            IList<EnumInfos<T>> enumInfos = Initialize().ToList();

            _valueToInfos = enumInfos.ToDictionary(x => x.Value);
            _descriptionToInfos = enumInfos.Where(x => x.Description != null)
                                           .ToDictionary(x => x.Description);
        }

        public static IEnumerable<T> GetValues()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static string GetName(T value)
        {
            return Enum.GetName(typeof(T), value);
        }

        public static IEnumerable<string> GetNames()
        {
            return Enum.GetNames(typeof(T));
        }

        public static string GetDescription(T value)
        {
            EnumInfos<T> info;
            return _valueToInfos.TryGetValue(value, out info)
                       ? info.Description
                       : null;
        }

        public static IEnumerable<string> GetDescriptions()
        {
            return _descriptionToInfos.Keys;
        }

        public static T ParseDescription(string description)
        {
            return _descriptionToInfos[description].Value;
        }

        public static bool TryParseDescription(string description, out T result)
        {
            EnumInfos<T> info = null;
            if (description != null)
                _descriptionToInfos.TryGetValue(description, out info);
            result = info?.Value ?? default(T);
            return info != null;
        }

        public static T Parse(string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }

        public static bool TryParse(string name, out T result)
        {
            return Enum.TryParse(name, false, out result);
        }

        public static T Cast(int input)
        {
            return (T)Enum.ToObject(typeof(T), input);
        }

        public static bool TryCast(int input, out T result)
        {
            try
            {
                result = (T)Enum.ToObject(typeof(T), input);
                return true;
            }
            catch
            {
                // ignored
            }

            result = default(T);
            return false;
        }

        public static TTarget ChangeTo<TTarget>(T input) where TTarget : struct
        {
            return (TTarget)Enum.Parse(typeof(TTarget), Enum.GetName(typeof(T), input) ?? "");
        }

        public static bool TryChangeTo<TTarget>(T input, out TTarget result) where TTarget : struct
        {
            return Enum.TryParse(Enum.GetName(typeof(T), input), false, out result);
        }

        public static bool IsValueDefined(int value)
        {
            try
            {
                return Enum.IsDefined(typeof(T), value);
            }
            catch
            {
                // ignored
            }

            return false;
        }

        public static bool IsNameDefined(string name)
        {
            try
            {
                return Enum.IsDefined(typeof(T), name);
            }
            catch
            {
                // ignored
            }

            return false;
        }

        public static bool IsDescriptionDefined(string description)
        {
            if (description != null)
                return _descriptionToInfos.ContainsKey(description);

            return false;
        }

        public static IEnumerable<EnumInfos<T>> GetEnumInfos()
        {
            return _valueToInfos.Values;
        }

        private static IEnumerable<EnumInfos<T>> Initialize()
        {
            Type type = typeof(T);
            return Enum.GetValues(type)
                       .Cast<T>()
                       .Select(enumValue => new EnumInfos<T>
                                            {
                                                Value = enumValue,
                                                Description = type.GetField(enumValue.ToString())
                                                                  .GetCustomAttributes(typeof(DescriptionAttribute), false)
                                                                  .Cast<DescriptionAttribute>()
                                                                  .Select(attribute => attribute.Description)
                                                                  .FirstOrDefault(),
                                                Name = Enum.GetName(typeof(T), enumValue)
                                            });
        }
    }
}
