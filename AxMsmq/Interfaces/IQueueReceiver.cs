
namespace AxMsmq.Interfaces
{
    public interface IQueueReceiver : IQueue
    {
        IQueueMessage Receive();
    }
}
