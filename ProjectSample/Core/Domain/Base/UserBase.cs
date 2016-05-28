using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace ProjectSample.Core.Domain.Base
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