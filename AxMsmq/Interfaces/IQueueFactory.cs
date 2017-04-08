using System.Collections.Generic;

namespace AxMsmq.Interfaces
{
    public interface IQueueFactory<TQueueMessage> where TQueueMessage : class
    {
        IList<IQueueAddress> GetExistingQueues(string hostName);

        IQueueReceiver<TQueueMessage> GetOrCreateReceiver(IQueueAddress address);
        IQueueSender<TQueueMessage> GetOrCreateSender(IQueueAddress address);
    }
}