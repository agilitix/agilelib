using System;
using System.Collections.Generic;

namespace AxExtensions
{
    public static class RandomExtensions
    {
        public static T NextOf<T>(this Random self, params T[] things)
        {
            IList<string> l = new[] {""};
            l.Add(new List<string>());
            return things[self.Next(things.Length)];
        }
    }
}
