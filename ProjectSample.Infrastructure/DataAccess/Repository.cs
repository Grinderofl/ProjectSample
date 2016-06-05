using System.Collections.Generic;
using ProjectSample.Infrastructure.DataAccess.Queries;

namespace ProjectSample.Infrastructure.DataAccess
{
    public abstract class Repository : IRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        protected Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public abstract T Find<T>(object id);
        public abstract IEnumerable<T> FindAll<T>();
        public abstract TResult Query<TResult>(QueryObject<TResult> query);

        public virtual void Save<T>(T entity)
        {
            _unitOfWork.Begin();
            SaveCore(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete<T>(T entity)
        {
            DeleteCore(entity);
        }

        protected abstract void SaveCore<T>(T entity);

        protected abstract void DeleteCore<T>(T entity);
    }
}