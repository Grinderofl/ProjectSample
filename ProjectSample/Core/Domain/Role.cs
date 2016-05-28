using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Core.Domain.Base;

namespace ProjectSample.Core.Domain
{
    public class Role : Entity<int>
    {
        private Role(int id, string name)
        {
            Id = id;
            Name = name;
        }

        protected Role()
        {
            
        }

        public static Role Administrator = new Role(1, "Administrator");
        public static Role User = new Role(2, "User");

        public virtual string Name { get; set; }
    }
}