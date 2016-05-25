namespace ProjectSample.Core.Infrastructure.DataAccess.List
{
    public interface IListService<T>
    {
        ListResult<T> GetListResult(PageDescriptor<T> pageDescriptor);
    }
}