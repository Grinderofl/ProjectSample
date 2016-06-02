namespace ProjectSample.Infrastructure.DataAccess.Queries
{
    public abstract class QueryObject<TResult>
    {
        public abstract TResult Execute(IRepository repository);
    }
}