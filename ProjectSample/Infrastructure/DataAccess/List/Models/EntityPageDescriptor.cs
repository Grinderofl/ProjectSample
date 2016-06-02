using ProjectSample.Infrastructure.Domain.Base;

namespace ProjectSample.Infrastructure.DataAccess.List.Models
{
    public class EntityPageDescriptor<TEntity> : PageDescriptor<TEntity> where TEntity : Entity<long>
    {
        public EntityPageDescriptor()
        {
            SortProperty = t => t.Id;
        }
    }
}