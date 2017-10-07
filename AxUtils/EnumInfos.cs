using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AxUtils
{
    public class EnumInfos<T> where T : struct
    {
        public T Value;
        public int Number;
        public string Name;
        public string Description;
    }
}
