using System;
using NHibernate;
using ProjectSample.Infrastructure.DataAccess;

namespace ProjectSample.Infrastructure.NHibernate.DataAccess.Impl
{
    public class StackBasedUnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private int _stack;
        private ITransaction _transaction;

        public StackBasedUnitOfWork(ISession session)
        {
            _session = session;
        }

        public virtual void Begin()
        {
            _stack++;
            if (_transaction == null)
                _transaction = _session.BeginTransaction();
        }

        public virtual bool Commit()
        {
            _stack--;
            if (_stack == 0)
            {
                try
                {
                    _transaction.Commit();
                    _transaction = null;
                    return true;
                }
                catch (Exception)
                {
                    Rollback();
                    return false;
                }
            }
            return true;
        }

        public virtual void Rollback()
        {
            _stack = 0;
            _transaction.Rollback();
            _transaction = null;
        }
    }
}