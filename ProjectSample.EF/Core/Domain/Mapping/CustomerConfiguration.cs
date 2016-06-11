using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjectSample.EF.Core.Domain.Mapping
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            HasRequired(x => x.Basket).WithRequiredPrincipal(t => t.Customer);
        }
    }
}