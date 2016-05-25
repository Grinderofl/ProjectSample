using ProjectSample.Core.Domain.Base;

namespace ProjectSample.Core.Infrastructure.DataAccess.List
{
    public class EntityPageDescriptor<TEntity> : PageDescriptor<TEntity> where TEntity : Entity<long>
    {
        public EntityPageDescriptor()
        {
            SortProperty = t => t.Id;
        }
    }
}