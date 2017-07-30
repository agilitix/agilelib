using System.Collections.Generic;

namespace AxFixEntities.Messages
{
    public class Group
    {
        internal Group(string name, bool required, IEnumerable<Field> fields, IEnumerable<Component> components)
        {
            Required = required;
            Name = name;
            Fields = fields;
            Components = components;
        }

        public string Name { get; }
        public bool Required { get; }
        public IEnumerable<Field> Fields { get; }
        public IEnumerable<Component> Components { get; }
    }
}