using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProjectSample.EF.Infrastructure.Common.Models;
using ProjectSample.EF.Infrastructure.EntityFramework.Queries;

namespace ProjectSample.EF.Core.Domain.Queries
{
    public class FindCustomerByIdentityQuery : EfQueryObject<Customer>
    {
        private readonly Identifier _identifier;

        public FindCustomerByIdentityQuery(Identifier identifier)
        {
            _identifier = identifier;
        }

        public override Customer Execute(DbContext context)
        {
            return context.Set<Customer>().SingleOrDefault(x => x.Identifier == _identifier);
        }
    }
}