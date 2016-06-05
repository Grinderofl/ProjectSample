using ProjectSample.Infrastructure.Security.Domain;

namespace ProjectSample.Core.Domain
{
    public class User : UserBase
    {
        public virtual Customer Customer { get; set; }
    }
}