using ProjectSample.Core.Infrastructure.DataAccess;

namespace ProjectSample.Core.Infrastructure.Queries
{
    public abstract class QueryObject<TResult>
    {
        public abstract TResult Execute(IRepository repository);
    }
}