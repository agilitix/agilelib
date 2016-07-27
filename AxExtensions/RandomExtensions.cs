using System;

namespace AxExtensions
{
    public static class RandomExtensions
    {
        public static T NextThing<T>(this Random self, params T[] things)
        {
            return things[self.Next(things.Length)];
        }
    }
}
