using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AxUtils
{
    public static class EnumUtils<T> where T : struct
    {
        private static readonly IDictionary<T, EnumInfos<T>> _valueToInfos;
        private static readonly IDictionary<int, EnumInfos<T>> _numberToInfos;
        private static readonly IDictionary<string, EnumInfos<T>> _nameToInfos;

        static EnumUtils()
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new NotSupportedException();
            }

            IList<EnumInfos<T>> enumInfos = Initialize().ToList();

            _valueToInfos = enumInfos.ToDictionary(x => x.Value);
            _numberToInfos = enumInfos.ToDictionary(x => x.Number);
            _nameToInfos = enumInfos.ToDictionary(x => x.Name);
        }

        public static IEnumerable<T> GetValues()
        {
            return _valueToInfos.Keys;
        }

        public static string GetName(T enumValue)
        {
            EnumInfos<T> info;
            return _valueToInfos.TryGetValue(enumValue, out info)
                       ? info.Name
                       : null;
        }

        public static IEnumerable<string> GetNames()
        {
            return _nameToInfos.Keys;
        }

        public static string GetDescription(T enumValue)
        {
            EnumInfos<T> info;
            return _valueToInfos.TryGetValue(enumValue, out info)
                       ? info.Description
                       : null;
        }

        public static IEnumerable<string> GetDescriptions()
        {
            return _valueToInfos.Values.Select(x => x.Description);
        }

        public static int GetNumber(T enumValue)
        {
            return ToInt(enumValue);
        }

        public static IEnumerable<int> GetNumbers()
        {
            return _numberToInfos.Keys;
        }

        public static T FromDescription(string enumDescription)
        {
            T enumOutput;
            if (TryFromDescription(enumDescription, out enumOutput))
                return enumOutput;

            throw new ArgumentOutOfRangeException(nameof(enumDescription));
        }

        public static T FromDescriptionOrDefault(string enumDescription, T defaultValue)
        {
            T enumOutput;
            TryFromDescriptionOrDefault(enumDescription, out enumOutput, defaultValue);
            return enumOutput;
        }

        public static bool TryFromDescription(string enumDescription, out T enumOutput)
        {
            EnumInfos<T> info = _valueToInfos.Values.FirstOrDefault(x => enumDescription != null && x.Description == enumDescription);
            enumOutput = info?.Value ?? default(T);
            return info != null;
        }

        public static bool TryFromDescriptionOrDefault(string enumDescription, out T enumOutput, T defaultValue)
        {
            if (TryFromDescription(enumDescription, out enumOutput))
                return true;

            enumOutput = defaultValue;
            return false;
        }

        public static T FromName(string enumName)
        {
            return _nameToInfos[enumName].Value;
        }

        public static T FromNameOrDefault(string enumName, T defaultValue)
        {
            T enumOutput;
            TryFromNameOrDefault(enumName, out enumOutput, defaultValue);
            return enumOutput;
        }

        public static bool TryFromName(string enumName, out T enumOutput)
        {
            EnumInfos<T> info = null;
            if (enumName != null)
                _nameToInfos.TryGetValue(enumName, out info);
            enumOutput = info?.Value ?? default(T);
            return info != null;
        }

        public static bool TryFromNameOrDefault(string enumName, out T enumOutput, T defaultValue)
        {
            if (TryFromName(enumName, out enumOutput))
                return true;

            enumOutput = defaultValue;
            return false;
        }

        public static T Cast(int enumNumber)
        {
            return _numberToInfos[enumNumber].Value;
        }

        public static T CastOrDefault(int enumNumber, T defaultValue)
        {
            T enumOutput;
            TryCastOrDefault(enumNumber, out enumOutput, defaultValue);
            return enumOutput;
        }

        public static bool TryCast(int enumNumber, out T enumOutput)
        {
            EnumInfos<T> info;
            _numberToInfos.TryGetValue(enumNumber, out info);
            enumOutput = info?.Value ?? default(T);
            return info != null;
        }

        public static bool TryCastOrDefault(int enumNumber, out T enumOutput, T defaultValue)
        {
            if (TryCast(enumNumber, out enumOutput))
                return true;

            enumOutput = defaultValue;
            return false;
        }

        public static TTarget ChangeTo<TTarget>(T enumValue) where TTarget : struct
        {
            return EnumUtils<TTarget>.FromName(GetName(enumValue));
        }

        public static TTarget ChangeToOrDefault<TTarget>(T enumValue, TTarget defaultValue) where TTarget : struct
        {
            return EnumUtils<TTarget>.FromNameOrDefault(GetName(enumValue), defaultValue);
        }

        public static bool TryChangeTo<TTarget>(T enumValue, out TTarget enumOutput) where TTarget : struct
        {
            return EnumUtils<TTarget>.TryFromName(GetName(enumValue), out enumOutput);
        }

        public static bool TryChangeToOrDefault<TTarget>(T enumValue, out TTarget enumOutput, TTarget defaultValue) where TTarget : struct
        {
            return EnumUtils<TTarget>.TryFromNameOrDefault(GetName(enumValue), out enumOutput, defaultValue);
        }

        public static bool IsNumberDefined(int enumNumber)
        {
            return _numberToInfos.ContainsKey(enumNumber);
        }

        public static bool IsNameDefined(string enumName)
        {
            return enumName != null && _nameToInfos.ContainsKey(enumName);
        }

        public static bool IsDescriptionDefined(string enumDescription)
        {
            return _valueToInfos.Values.Any(x => enumDescription != null && x.Description == enumDescription);
        }

        public static IEnumerable<EnumInfos<T>> GetEnumInfos()
        {
            return _valueToInfos.Values;
        }

        public static int ToInt(T enumValue)
        {
            return (int) (object) enumValue;
        }

        private static IEnumerable<EnumInfos<T>> Initialize()
        {
            Type type = typeof(T);
            return Enum.GetValues(type)
                       .Cast<T>()
                       .Select(enumValue =>
                               {
                                   string enumName = Enum.GetName(type, enumValue);
                                   return new EnumInfos<T>
                                          {
                                              Value = enumValue,
                                              Number = ToInt(enumValue),
                                              Description = type.GetField(enumName)
                                                                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                                                                .Cast<DescriptionAttribute>()
                                                                .Select(attribute => attribute.Description)
                                                                .FirstOrDefault(),
                                              Name = enumName,
                                          };
                               });
        }
    }
}
