namespace ProjectSample.Infrastructure.DataAccess
{
    public interface IUnitOfWork
    {
        void Begin();
        bool Commit();
        void Rollback();
    }
}