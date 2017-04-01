namespace AxMsmq.Interfaces
{
    public interface IQueueMessageTransformer<in TSource, out TTarget> where TSource : class where TTarget : class
    {
        TTarget Transform(TSource message);
    }
}