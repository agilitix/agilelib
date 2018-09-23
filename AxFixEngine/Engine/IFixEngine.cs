using System.Collections.Generic;
using AxFixEngine.Dialects;
using AxFixEngine.Handlers;
using QuickFix;

namespace AxFixEngine.Engine
{
    public interface IFixEngine
    {
        string ConfigFile { get; }
        IList<SessionID> Sessions { get; }
        IFixDialects Dialects { get; }
        IFixMessageHandlers Handlers { get; }

        void CreateApplication();

        void Start();
        void Stop();
    }
}
