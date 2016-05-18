using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using ProjectSample.Core.Infrastructure.DataAccess;
using ProjectSample.Core.Infrastructure.NHibernate.DataAccess.Impl;
using ProjectSample.Core.Infrastructure.Queries;

namespace ProjectSample.Core.Infrastructure.NHibernate.Queries
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