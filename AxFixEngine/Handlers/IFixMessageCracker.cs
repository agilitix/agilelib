using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickFix;

namespace AxFixEngine.Handlers
{
    public interface IFixMessageCracker
    {
        void CrackFrom(Message message, SessionID sessionID);
        void CrackTo(Message message, SessionID sessionID);
    }
}
