using System.Collections.Generic;

namespace AxMsmq.Interfaces
{
    public interface IQueuesManager
    {
        IList<IQueueUri> GetExisitingQueues(string host);

        IQueueReceiver GetOrCreateReceiver(IQueueUri uri);
        IQueueSender GetOrCreateSender(IQueueUri uri);
        IQueueListener GetOrCreateListener(IQueueUri uri);
    }
}
