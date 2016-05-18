using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectSample.Core.Infrastructure.Queries;

namespace ProjectSample.Core.Infrastructure.DataAccess
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
