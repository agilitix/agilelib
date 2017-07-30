using System.Collections.Generic;

namespace AxFixEntities.Messages
{
    public class Message
    {
        internal Message(string name, IEnumerable<Field> fields, IEnumerable<Group> groups, IEnumerable<Component> components)
        {
            Name = name;
            Fields = fields;
            Groups = groups;
            Components = components;
        }

        public string Name { get; }

        public IEnumerable<Field> Fields { get; }
        public IEnumerable<Group> Groups { get; }
        public IEnumerable<Component> Components { get; }
    }
}