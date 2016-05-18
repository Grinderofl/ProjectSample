using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Core.Domain.Base;

namespace ProjectSample.Core.Domain
{
    public class Product : Entity<long>
    {
        public virtual string Name { get; set; }
    }
}