using System.Collections.Generic;
using AxFixEngine.Handlers;
using QuickFix;

namespace AxFixEngine.Engine
{
    public interface IFixEngine
    {
        IList<SessionID> Sessions { get; }

        void CreateApplication(IFixMessageHandlerProvider messageHandlerProvider);

        void Start();
        void Stop();
    }
}
