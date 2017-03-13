using System;
using System.Collections;
using System.Collections.Generic;
using QuickFix;

namespace AxFixEngine.Extensions
{
    public static class DictionaryExtensions
    {
        public static DateTime GetTime(this Dictionary self, string settingName)
        {
            string setting = self.GetString(settingName);
            return (DateTime) Convert.ChangeType(setting, typeof(DateTime));
        }

        public static IEnumerable<KeyValuePair<string, string>> AsEnumerable(this Dictionary self)
        {
            IEnumerator enumerator = self.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<string, string> current = (KeyValuePair < string, string > )enumerator.Current;
                yield return current;
            }
        }
    }
}
