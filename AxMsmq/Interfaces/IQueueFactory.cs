using System.Collections.Generic;

namespace AxMsmq.Interfaces
{
    public interface IQueueFactory<TQueueMessage> where TQueueMessage : class
    {
        IList<IQueueUri> GetExistingQueues(string hostName);

        IQueueReceiver<TQueueMessage> GetOrCreateReceiver(IQueueUri uri);
        IQueueSender<TQueueMessage> GetOrCreateSender(IQueueUri uri);
        IQueueListener<TQueueMessage> GetOrCreateListener(IQueueUri uri);
    }
}