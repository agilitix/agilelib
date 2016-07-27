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

        public static TValue GetOrFallback<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey key, TValue fallback = default(TValue))
        {
            TValue result;
            if (!self.TryGetValue(key, out result))
            {
                return fallback;
            }
            return result;
        }
    }
}
