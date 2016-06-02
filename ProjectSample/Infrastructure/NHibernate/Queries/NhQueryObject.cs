using System;
using NHibernate;
using ProjectSample.Infrastructure.DataAccess;
using ProjectSample.Infrastructure.DataAccess.Queries;
using ProjectSample.Infrastructure.NHibernate.DataAccess.Impl;

namespace ProjectSample.Infrastructure.NHibernate.Queries
{
    public abstract class NhQueryObject<TResult> : QueryObject<TResult>
    {
        protected NhRepository EnsureNhRepo(IRepository repository)
        {
            var nhRepo = repository as NhRepository;
            if(nhRepo == null)
                throw new Exception("Repo is not NH Repo");

            return nhRepo;
        }

        public override TResult Execute(IRepository repository)
        {
            var nhRepo = EnsureNhRepo(repository);
            return ExecuteCore(nhRepo.Session);
        }

        protected abstract TResult ExecuteCore(ISession session);
    }
}