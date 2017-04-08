using System.Collections.Generic;

namespace AxMsmq.Interfaces
{
    public interface IQueueFactory<TQueueMessage> where TQueueMessage : class
    {
        bool CreateQueue(IQueuePath queuePath);

        IList<IQueuePath> GetExistingQueues(string hostName);

        IQueueReceiver<TQueueMessage> GetOrCreateReceiver(IQueuePath path);
        IQueueSender<TQueueMessage> GetOrCreateSender(IQueuePath path);
    }
}