using System;
using System.Collections.Generic;

namespace AxExtensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey key, Func<TValue> createValue)
        {
            TValue result;
            if (!self.TryGetValue(key, out result))
            {
                result = createValue();
                self[key] = result;
            }
            return result;
        }

        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey key, TValue defaultValue = default(TValue))
        {
            TValue result;
            return self.TryGetValue(key, out result)
                ? result
                : defaultValue;
        }
    }
}