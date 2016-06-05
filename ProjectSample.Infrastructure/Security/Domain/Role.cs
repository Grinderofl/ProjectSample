using ProjectSample.Infrastructure.Domain.Base;

namespace ProjectSample.Infrastructure.Security.Domain
{
    public class Role : Entity<int>
    {
        public static Role Administrator = new Role(1, "Administrator");
        public static Role User = new Role(2, "User");

        private Role(int id, string name)
        {
            Id = id;
            Name = name;
        }

        protected Role()
        {
        }

        public virtual string Name { get; set; }
    }
}