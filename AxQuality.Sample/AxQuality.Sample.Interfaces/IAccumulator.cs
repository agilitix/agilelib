namespace AxQuality.Sample.Interfaces
{
    public interface IAccumulator
    {
        double Value { get; set; }
        void Add(double number);
    }
}