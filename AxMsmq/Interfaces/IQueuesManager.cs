using System.Collections.Generic;

namespace AxMsmq.Interfaces
{
    public interface IQueuesManager<T> where T : class
    {
        IList<IQueueUri> GetExistingQueues(string hostName);

        IQueueReceiver<T> GetOrCreateReceiver(IQueueUri uri);
        IQueueSender<T> GetOrCreateSender(IQueueUri uri);
        IQueueListener<T> GetOrCreateListener(IQueueUri uri);
    }
}