namespace AxFixEntities.Messages
{
    public class Field
    {
        internal Field(string name, bool required)
        {
            Required = required;
            Name = name;
        }

        public string Name { get; }
        public bool Required { get; }
    }
}