namespace AxFixEntities.FixSpec
{
    public class SpecValue
    {
        public SpecValue(string enumValue, string description)
        {
            EnumValue = enumValue;
            Description = description;
        }

        public string EnumValue { get; }
        public string Description { get; }
    }
}
