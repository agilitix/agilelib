using System;
using System.Reactive.Subjects;
using AxFixEngine.Interfaces;
using QuickFix;
using QuickFix.DataDictionary;

namespace AxFixEngine.Handlers
{
    public class FixMessageReactiveHandlerBase : IFixMessageHandler
    {
        private readonly ISubject<MessageEvent> _adminSubject = new Subject<MessageEvent>();
        private readonly ISubject<MessageEvent> _appSubject = new Subject<MessageEvent>();
        private readonly ISubject<LoginEvent> _connectionSubject = new Subject<LoginEvent>();

        public enum LoginStatus
        {
            Logon,
            Logout,
        }

        public enum MessageDirection
        {
            To,
            From,
        }

        public struct LoginEvent
        {
            public LoginStatus Status { get; }
            public SessionID SessionID { get; }

            public LoginEvent(LoginStatus status, SessionID sessionId)
            {
                Status = status;
                SessionID = sessionId;
            }
        }

        public struct MessageEvent
        {
            public MessageDirection Direction { get; }
            public SessionID SessionID { get; }
            public Message Message { get; }
            public DataDictionary DataDictionary { get; }

            public MessageEvent(MessageDirection direction, Message message, SessionID sessionId)
            {
                Direction = direction;
                SessionID = sessionId;
                Message = message;
                DataDictionary = Session.LookupSession(sessionId).SessionDataDictionary;
            }
        }

        public IObservable<LoginEvent> ConnectionEvent => _connectionSubject;
        public IObservable<MessageEvent> AdminEvent => _adminSubject;
        public IObservable<MessageEvent> AppEvent => _appSubject;

        void IFixMessageHandler.OnLogon(SessionID sessionId)
        {
            _connectionSubject.OnNext(new LoginEvent(LoginStatus.Logon, sessionId));
        }

        void IFixMessageHandler.OnLogout(SessionID sessionId)
        {
            _connectionSubject.OnNext(new LoginEvent(LoginStatus.Logout, sessionId));
        }

        void IFixMessageHandler.ToAdmin(Message message, SessionID sourceSessionId)
        {
            _adminSubject.OnNext(new MessageEvent(MessageDirection.To, message, sourceSessionId));
        }

        void IFixMessageHandler.FromAdmin(Message message, SessionID sourceSessionId)
        {
            _adminSubject.OnNext(new MessageEvent(MessageDirection.From, message, sourceSessionId));
        }

        void IFixMessageHandler.ToApp(Message message, SessionID sourceSessionId)
        {
            _appSubject.OnNext(new MessageEvent(MessageDirection.To, message, sourceSessionId));
        }

        void IFixMessageHandler.FromApp(Message message, SessionID sourceSessionId)
        {
            _appSubject.OnNext(new MessageEvent(MessageDirection.From, message, sourceSessionId));
        }
    }
}
