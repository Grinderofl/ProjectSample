using ProjectSample.Infrastructure.Domain.Base;

namespace ProjectSample.Core.Domain
{
    public class Product : Entity<long>
    {
        public Product(string name)
        {
            Name = name;
        }

        public Product()
        {
            
        }
        public virtual string Name { get; set; }
    }
}