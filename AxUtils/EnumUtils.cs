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
        private static readonly Lazy<IDictionary<T, EnumInfos<T>>> _valueToInfos =
            new Lazy<IDictionary<T, EnumInfos<T>>>(() => new Dictionary<T, EnumInfos<T>>());

        private static readonly Lazy<IDictionary<string, EnumInfos<T>>> _nameToInfos =
            new Lazy<IDictionary<string, EnumInfos<T>>>(() => new Dictionary<string, EnumInfos<T>>());

        private static readonly Lazy<IDictionary<string, EnumInfos<T>>> _descriptionToInfos =
            new Lazy<IDictionary<string, EnumInfos<T>>>(() => new Dictionary<string, EnumInfos<T>>());

        static EnumUtils()
        {
            Type type = typeof(T);
            if (!type.IsEnum)
            {
                throw new Exception();
            }

            IList<EnumInfos<T>> enumInfos = Initialize().ToList();

            enumInfos.Aggregate(_valueToInfos.Value,
                                (accu, item) =>
                                {
                                    accu[item.Value] = item;
                                    return accu;
                                });

            enumInfos.Aggregate(_nameToInfos.Value,
                                (accu, item) =>
                                {
                                    accu[item.Name] = item;
                                    return accu;
                                });

            enumInfos.Where(x => !string.IsNullOrWhiteSpace(x.Description))
                     .Aggregate(_descriptionToInfos.Value,
                                (accu, item) =>
                                {
                                    accu[item.Description] = item;
                                    return accu;
                                });
        }

        public static IEnumerable<T> GetValues()
        {
            return _valueToInfos.Value.Keys;
        }

        public static string GetName(T value)
        {
            EnumInfos<T> info;
            return _valueToInfos.Value.TryGetValue(value, out info) ? info.Name : null;
        }

        public static IEnumerable<string> GetNames()
        {
            return _nameToInfos.Value.Keys;
        }

        public static string GetDescription(T value)
        {
            EnumInfos<T> info;
            return _valueToInfos.Value.TryGetValue(value, out info) ? info.Description : null;
        }

        public static IEnumerable<string> GetDescriptions()
        {
            return _descriptionToInfos.Value.Keys;
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
            if (!string.IsNullOrWhiteSpace(description) && _descriptionToInfos.Value.TryGetValue(description, out info))
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
            if (!string.IsNullOrWhiteSpace(name) && _nameToInfos.Value.TryGetValue(name, out info))
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
                if (_valueToInfos.Value.TryGetValue((T) Enum.ToObject(type, input), out info))
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
            return !string.IsNullOrWhiteSpace(name) && _nameToInfos.Value.TryGetValue(name, out info);
        }

        public static bool IsDescriptionDefined(string description)
        {
            EnumInfos<T> info;
            return !string.IsNullOrWhiteSpace(description) && _descriptionToInfos.Value.TryGetValue(description, out info);
        }

        public static IEnumerable<EnumInfos<T>> GetEnumInfos()
        {
            return _valueToInfos.Value.Values;
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
                                                                  .FirstOrDefault(),
                                                Name = Enum.GetName(typeof (T), enumValue)
                                            });
        }
    }
}