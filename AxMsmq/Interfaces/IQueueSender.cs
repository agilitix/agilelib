
namespace AxMsmq.Interfaces
{
    public interface IQueueSender : IQueue
    {
        void Send(IQueueMessage message);
    }
}
