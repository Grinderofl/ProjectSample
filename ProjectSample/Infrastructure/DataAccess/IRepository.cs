using System.Collections.Generic;
using ProjectSample.Infrastructure.DataAccess.Queries;

namespace ProjectSample.Infrastructure.DataAccess
{
    public interface IRepository
    {
        T Find<T>(object id);
        IEnumerable<T> FindAll<T>();
        TResult Query<TResult>(QueryObject<TResult> query);
        void Save<T>(T entity);
        void Delete<T>(T entity);
    }
}
