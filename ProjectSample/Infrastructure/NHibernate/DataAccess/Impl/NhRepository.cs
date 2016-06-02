using System.Collections.Generic;
using NHibernate;
using ProjectSample.Infrastructure.DataAccess;
using ProjectSample.Infrastructure.DataAccess.Queries;

namespace ProjectSample.Infrastructure.NHibernate.DataAccess.Impl
{
    public class NhRepository : Repository
    {
        public NhRepository(IUnitOfWork unitOfWork, ISession session) : base(unitOfWork)
        {
            Session = session;
        }

        public ISession Session { get; }

        public override T Find<T>(object id)
        {
            return Session.Get<T>(id);
        }

        public override IEnumerable<T> FindAll<T>()
        {
            return Session.CreateCriteria(typeof(T)).Future<T>();
        }

        public override TResult Query<TResult>(QueryObject<TResult> query)
        {
            return query.Execute(this);
        }

        protected override void SaveCore<T>(T entity)
        {
            Session.SaveOrUpdate(entity);
        }

        protected override void DeleteCore<T>(T entity)
        {
            Session.Delete(entity);
        }
    }
}