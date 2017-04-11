using AxCommonLogger;
using AxCommonLogger.Interfaces;
using AxFixEngine.Interfaces;
using QuickFix;

namespace AxFixEngine
{
    public abstract class FixMessageHandlerBase : MessageCracker, IFixMessageHandler
    {
        protected static ILoggerFacade Log = LoggerFacadeProvider.GetLogger<FixMessageHandlerBase>();

        public virtual void OnLogon(SessionID sessionId)
        {
        }

        public virtual void OnLogout(SessionID sessionId)
        {
        }

        public virtual void SendingToAdmin(Message message, SessionID sourceSessionId)
        {
        }

        public virtual void ReceivingFromAdmin(Message message, SessionID sourceSessionId)
        {
            Crack(message, sourceSessionId);
        }

        public virtual void SendingToApp(Message message, SessionID sourceSessionId)
        {
        }

        public virtual void ReceivingFromApp(Message message, SessionID sourceSessionId)
        {
            Crack(message, sourceSessionId);
        }

        public virtual void SendToTarget(Message message, SessionID targetSessionId)
        {
            try
            {
                Session.SendToTarget(message, targetSessionId);
            }
            catch (SessionNotFound e)
            {
                Log.Error(e.Message);
                throw;
            }
        }
    }
}
