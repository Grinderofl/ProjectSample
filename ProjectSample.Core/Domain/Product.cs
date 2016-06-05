using ProjectSample.Infrastructure.Domain.Base;

namespace ProjectSample.Core.Domain
{
    public class Product : Entity<long>
    {
        public virtual string Name { get; set; }
    }
}