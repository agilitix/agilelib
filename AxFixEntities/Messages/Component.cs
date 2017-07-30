using System.Collections.Generic;

namespace AxFixEntities.Messages
{
    public class Component
    {
        internal Component(string name, bool required)
        {
            Name = name;
            Required = required;
        }

        internal Component(string name, IEnumerable<Field> fields, IEnumerable<Group> groups)
        {
            Name = name;
            Fields = fields;
            Groups = groups;
        }

        public string Name { get; }
        public bool Required{ get; }
        public IEnumerable<Field> Fields { get; }
        public IEnumerable<Group> Groups { get; }
    }
}