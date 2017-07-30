using System.Collections.Generic;

namespace AxFixEntities.FixSpec
{
    public class SpecField
    {
        internal SpecField(int tag, string name, string type, IEnumerable<SpecValue> values)
        {
            Tag = tag;
            Name = name;
            Type = type;
            Values = values;
        }

        public int Tag { get; }
        public string Name { get; }
        public string Type { get; }
        public IEnumerable<SpecValue> Values { get; }
    }
}
