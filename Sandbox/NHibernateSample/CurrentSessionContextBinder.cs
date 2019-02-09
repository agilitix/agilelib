using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace nhibertest
{
    public class CurrentSessionContextBinder
    {
        public bool HasBind(ISessionFactory sessionFactory)
        {
            return CurrentSessionContext.HasBind(sessionFactory);
        }

        public ISession Bind(ISessionFactory sessionFactory)
        {
            ISession session = sessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
            return session;
        }

        public ISession Unbind(ISessionFactory sessionFactory)
        {
            return CurrentSessionContext.Unbind(sessionFactory);
        }
    }
}
