namespace AxFixEntities
{
    class Program
    {
        static void Main(string[] args)
        {
            EnumsGenerator.Generate();
            MessagesGenerator.Generate();
            ComponentsGenerator.Generate();
            ConvertersGenerator.Generate();
        }
    }
}
