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
        private static readonly IDictionary<string, EnumInfos<T>> _nameToInfos;
        private static readonly IDictionary<string, EnumInfos<T>> _descriptionToInfos;

        static EnumUtils()
        {
            Type type = typeof(T);
            if (!type.IsEnum)
            {
                throw new NotSupportedException();
            }

            IList<EnumInfos<T>> enumInfos = Initialize().ToList();

            _valueToInfos = enumInfos.ToDictionary(x => x.Value);
            _nameToInfos = enumInfos.ToDictionary(x => x.Name);
            _descriptionToInfos = enumInfos.ToDictionary(x => x.Description);
        }

        public static IEnumerable<T> GetValues()
        {
            return _valueToInfos.Keys;
        }

        public static string GetName(T value)
        {
            EnumInfos<T> info;
            return _valueToInfos.TryGetValue(value, out info) ? info.Name : null;
        }

        public static IEnumerable<string> GetNames()
        {
            return _nameToInfos.Keys;
        }

        public static string GetDescription(T value)
        {
            EnumInfos<T> info;
            return _valueToInfos.TryGetValue(value, out info) ? info.Description : null;
        }

        public static IEnumerable<string> GetDescriptions()
        {
            return _descriptionToInfos.Keys;
        }

        public static T ParseDescription(string description)
        {
            T result;
            if (!TryParseDescription(description, out result))
            {
                throw new InvalidEnumArgumentException();
            }
            return result;
        }

        public static bool TryParseDescription(string description, out T result)
        {
            EnumInfos<T> info;
            if (!string.IsNullOrWhiteSpace(description) && _descriptionToInfos.TryGetValue(description, out info))
            {
                result = info.Value;
                return true;
            }
            result = default(T);
            return false;
        }

        public static T ParseName(string name)
        {
            T result;
            if (!TryParseName(name, out result))
            {
                throw new InvalidEnumArgumentException();
            }
            return result;
        }

        public static bool TryParseName(string name, out T result)
        {
            EnumInfos<T> info;
            if (!string.IsNullOrWhiteSpace(name) && _nameToInfos.TryGetValue(name, out info))
            {
                result = info.Value;
                return true;
            }
            result = default(T);
            return false;
        }

        public static T Cast(int input)
        {
            T result;
            if (!TryCast(input, out result))
            {
                throw new InvalidEnumArgumentException();
            }
            return result;
        }

        public static bool TryCast(int input, out T result)
        {
            try
            {
                Type type = typeof (T);
                EnumInfos<T> info;
                if (_valueToInfos.TryGetValue((T) Enum.ToObject(type, input), out info))
                {
                    result = info.Value;
                    return true;
                }
            }
            catch
            {
            }
            result = default(T);
            return false;
        }

        public static bool IsValueDefined(int input)
        {
            T result;
            return TryCast(input, out result);
        }

        public static bool IsNameDefined(string name)
        {
            EnumInfos<T> info;
            return !string.IsNullOrWhiteSpace(name) && _nameToInfos.TryGetValue(name, out info);
        }

        public static bool IsDescriptionDefined(string description)
        {
            EnumInfos<T> info;
            return !string.IsNullOrWhiteSpace(description) && _descriptionToInfos.TryGetValue(description, out info);
        }

        public static IEnumerable<EnumInfos<T>> GetEnumInfos()
        {
            return _valueToInfos.Values;
        }

        private static IEnumerable<EnumInfos<T>> Initialize()
        {
            Type type = typeof (T);
            return Enum.GetValues(type)
                       .Cast<T>()
                       .Select(enumValue => new EnumInfos<T>
                                            {
                                                Value = enumValue,
                                                Description = type.GetField(enumValue.ToString())
                                                                  .GetCustomAttributes(typeof (DescriptionAttribute), false)
                                                                  .Cast<DescriptionAttribute>()
                                                                  .Select(attribute => attribute.Description)
                                                                  .FirstOrDefault() ?? enumValue.ToString(),
                                                Name = Enum.GetName(typeof (T), enumValue)
                                            });
        }
    }
}