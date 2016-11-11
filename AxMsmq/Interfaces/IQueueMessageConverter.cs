namespace AxMsmq.Interfaces
{
    public interface IQueueMessageConverter<in TSource, out TTarget>
        where TSource : class
        where TTarget : class
    {
        TTarget Convert(TSource source);
    }
}