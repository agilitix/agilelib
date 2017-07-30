namespace AxFixEntities.TypeMapping
{
    public class TypeMapping
    {
        public TypeMapping(string fixType, string clrType, string parseExpression)
        {
            FixType = fixType;
            ClrType = clrType;
            ParseExpression = parseExpression;
        }

        public string FixType { get; }
        public string ClrType { get; }
        public string ParseExpression { get; }
    }
}
