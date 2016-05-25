﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Linq;
using ProjectSample.Core.Application.Models;
using ProjectSample.Core.Infrastructure.NHibernate.Queries;

namespace ProjectSample.Core.Domain.Queries
{
    public class FindCustomerByIdentityQuery : NhQueryObject<Customer>
    {
        private readonly CustomerIdentity _identity;

        public FindCustomerByIdentityQuery(CustomerIdentity identity)
        {
            _identity = identity;
        }

        protected override Customer ExecuteCore(ISession session)
        {
            return session.Query<Customer>().SingleOrDefault(s => s.Identifier == _identity);
        }
    }
}