using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Linq;
using ProjectSample.Areas.Shared.Models;
using ProjectSample.Infrastructure.NHibernate.Queries;

namespace ProjectSample.Core.Domain.Queries
{
    public class FindCustomerByIdentityQuery : NhQueryObject<Customer>
    {
        private readonly Identifier _identity;

        public FindCustomerByIdentityQuery(Identifier identity)
        {
            _identity = identity;
        }

        protected override Customer ExecuteCore(ISession session)
        {
            return session.Query<Customer>().SingleOrDefault(s => s.Identifier == _identity);
        }
    }
}