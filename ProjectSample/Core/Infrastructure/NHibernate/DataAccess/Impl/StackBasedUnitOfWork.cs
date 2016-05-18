using System;
using NHibernate;
using ProjectSample.Core.Infrastructure.DataAccess;

namespace ProjectSample.Core.Infrastructure.NHibernate.DataAccess.Impl
{
    public class StackBasedUnitOfWork : IUnitOfWork
    {
        private int _stack;

        private readonly ISession _session;
        private ITransaction _transaction;
        public StackBasedUnitOfWork(ISession session)
        {
            _session = session;
        }

        public void Begin()
        {
            _stack++;
            if(_transaction == null)
            _transaction = _session.BeginTransaction();
        }

        public bool Commit()
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

        public void Rollback()
        {
            _stack = 0;
            _transaction.Rollback();
            _transaction = null;
        }
    }
}