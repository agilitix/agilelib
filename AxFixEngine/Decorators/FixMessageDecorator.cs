using System;
using System.Xml.Linq;
using AxFixEngine.Dialects;
using AxFixEngine.Extensions;
using QuickFix;
using QuickFix.Fields;
using Message = QuickFix.Message;

namespace AxFixEngine.Decorators
{
    public abstract class FixMessageDecorator : Message
    {
        private readonly IFixDialects _dialects;
        private readonly Message _message;

        protected FixMessageDecorator(IFixDialects dialects, Message message)
            : base(message)
        {
            _dialects = dialects;
            _message = message;
        }

        public void Accept(Action<Message> visitor)
        {
            visitor?.Invoke(_message);
        }

        public SessionID SessionID
        {
            get { return _message.GetSessionID(); }
            set { _message.SetSessionID(value); }
        }

        public string SenderCompID
        {
            get { return _message.Header.IsSetField(Tags.SenderCompID) ? _message.Header.GetString(Tags.SenderCompID) : null; }

            set
            {
                if (value != null)
                    _message.Header.SetField(new SenderCompID(value));
                else
                    _message.Header.RemoveField(Tags.SenderCompID);
            }
        }

        public string TargetCompID
        {
            get { return _message.Header.IsSetField(Tags.TargetCompID) ? _message.Header.GetString(Tags.TargetCompID) : null; }

            set
            {
                if (value != null)
                    _message.Header.SetField(new TargetCompID(value));
                else
                    _message.Header.RemoveField(Tags.TargetCompID);
            }
        }

        public string OnBehalfOfCompID
        {
            get { return _message.Header.IsSetField(Tags.OnBehalfOfCompID) ? _message.Header.GetString(Tags.OnBehalfOfCompID) : null; }

            set
            {
                if (value != null)
                    _message.Header.SetField(new OnBehalfOfCompID(value));
                else
                    _message.Header.RemoveField(Tags.OnBehalfOfCompID);
            }
        }

        public string DeliverToCompID
        {
            get { return _message.Header.IsSetField(Tags.DeliverToCompID) ? _message.Header.GetString(Tags.DeliverToCompID) : null; }

            set
            {
                if (value != null)
                    _message.Header.SetField(new DeliverToCompID(value));
                else
                    _message.Header.RemoveField(Tags.DeliverToCompID);
            }
        }

        public DateTime? SendingTime
        {
            get { return _message.Header.IsSetField(Tags.SendingTime) ? _message.Header.GetDateTime(Tags.SendingTime) : default(DateTime?); }

            set
            {
                if (value.HasValue)
                    _message.Header.SetField(new SendingTime(value.Value));
                else
                    _message.Header.RemoveField(Tags.SendingTime);
            }
        }

        public override string ToString()
        {
            return _message.ToString();
        }

        public XDocument ToXDocument()
        {
            return _message.ToXDocument(_dialects);
        }

        protected T DecoratedMessage<T>() where T : Message
        {
            return (T) _message;
        }
    }
}
