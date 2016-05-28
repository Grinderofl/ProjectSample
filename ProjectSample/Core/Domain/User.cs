using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using ProjectSample.Core.Domain.Base;

namespace ProjectSample.Core.Domain
{
    public class User : UserBase, IUser<Guid>
    {
        public virtual Customer Customer { get; set; }
    }
}