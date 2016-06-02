using System;
using ProjectSample.Infrastructure.Domain.Base;

namespace ProjectSample.Infrastructure.Security.Domain
{
    public abstract class UserBase : Entity<Guid>
    {
        public virtual string UserName { get; set; }

        public virtual string PasswordHash { get; set; }
        public virtual int Version { get; set; }
        public virtual Role Role { get; set; }

        public virtual bool IsInRole(Role role)
            => Role == role;
    }
}