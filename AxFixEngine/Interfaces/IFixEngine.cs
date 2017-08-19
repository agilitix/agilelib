﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickFix;

namespace AxFixEngine.Interfaces
{
    public interface IFixEngine
    {
        IList<SessionID> Sessions { get; }

        void InitializeFixApplication(IFixMessageHandlerProvider messageHandlerProvider);

        void Start();
        void Stop();
    }
}
