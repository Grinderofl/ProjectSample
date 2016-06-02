using ProjectSample.Infrastructure.DataAccess.List.Models;

namespace ProjectSample.Infrastructure.DataAccess.List
{
    public interface IListService<T>
    {
        ListResult<T> GetListResult(PageDescriptor<T> pageDescriptor);
    }
}