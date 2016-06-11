using System;
using System.Web;
using ProjectSample.EF.Infrastructure.Domain.Base;

namespace ProjectSample.EF.Core.Domain
{
    public class Customer : Entity<long>
    {
        public virtual string Identifier { get; set; }
        public virtual Basket Basket { get; protected set; }

        public virtual User User { get; set; }
    }
}