using System;
using System.Threading;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace nhibertest
{
    public enum SessionContextType
    {
        ThreadLocal,
        ThreadStatic,
        Call,
        WcfOperation,
        Web
    }

    public class SessionManager
    {
        protected readonly SessionContextType SessionContextType;
        protected Lazy<ISessionFactory> _sessionFactory;
        protected int _disposed;

        public ISession CurrentSession => GetCurrentSession();

        public SessionManager(Configuration configuration)
            : this(configuration, SessionContextType.ThreadStatic)
        {
        }

        public SessionManager(Configuration configuration, SessionContextType sessionContextType)
        {
            SessionContextType = sessionContextType;
            switch (SessionContextType)
            {
                case SessionContextType.ThreadLocal:
                    configuration.CurrentSessionContext<ThreadLocalSessionContext>();
                    break;
                case SessionContextType.ThreadStatic:
                    configuration.CurrentSessionContext<ThreadStaticSessionContext>();
                    break;
                case SessionContextType.Call:
                    configuration.CurrentSessionContext<CallSessionContext>();
                    break;
                case SessionContextType.WcfOperation:
                    configuration.CurrentSessionContext<WcfOperationSessionContext>();
                    break;
                case SessionContextType.Web:
                    configuration.CurrentSessionContext<WebSessionContext>();
                    break;
            }

            _sessionFactory = new Lazy<ISessionFactory>(configuration.BuildSessionFactory);
        }

        public ISession UnbindCurrentSession()
        {
            if (SessionContextType == SessionContextType.ThreadLocal)
            {
                return ThreadLocalSessionContext.Unbind(_sessionFactory.Value);
            }

            return CurrentSessionContext.Unbind(_sessionFactory.Value);
        }

        private ISession GetCurrentSession()
        {
            if (SessionContextType == SessionContextType.ThreadLocal || CurrentSessionContext.HasBind(_sessionFactory.Value))
            {
                return _sessionFactory.Value.GetCurrentSession();
            }

            ISession session = _sessionFactory.Value.OpenSession();
            CurrentSessionContext.Bind(session);
            return session;
        }

        private void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref _disposed, 1) == 1)
            {
                return;
            }

            if (disposing)
            {
                if (_sessionFactory.IsValueCreated)
                {
                    ISession session = UnbindCurrentSession();
                    session?.Dispose();
                    _sessionFactory.Value.Dispose();
                }
                _sessionFactory = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~SessionManager()
        {
            Dispose(false);
        }
    }
}
