using System;
using System.Data;
using NHibernate;

namespace nhibertest
{
    public class UnitOfWork : IDisposable
    {
        protected ITransaction _transaction;

        public UnitOfWork(ISession session)
        {
            _transaction = session.BeginTransaction();
        }

        public UnitOfWork(ISession session, IsolationLevel isolationLevel)
        {
            _transaction = session.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            if (_transaction?.IsActive ?? false)
            {
                _transaction.Commit();
            }
        }

        protected void Rollback()
        {
            if (_transaction?.IsActive ?? false)
            {
                _transaction.Rollback();
            }
        }

        public void Dispose()
        {
            Rollback();
            _transaction?.Dispose();
            _transaction = null;
        }
    }
}
