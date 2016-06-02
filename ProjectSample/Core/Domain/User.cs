using System;
using Microsoft.AspNet.Identity;
using ProjectSample.Infrastructure.Security.Domain;

namespace ProjectSample.Core.Domain
{
    public class User : UserBase, IUser<Guid>
    {
        public virtual Customer Customer { get; set; }
    }
}