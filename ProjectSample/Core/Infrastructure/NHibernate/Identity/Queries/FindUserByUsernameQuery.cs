using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Linq;
using ProjectSample.Core.Domain.Base;
using ProjectSample.Core.Infrastructure.NHibernate.Queries;

namespace ProjectSample.Core.Infrastructure.NHibernate.Identity.Queries
{
    public class FindUserByUsernameQuery : NhQueryObject<UserBase>
    {
        private readonly string _username;

        public FindUserByUsernameQuery(string username)
        {
            _username = username;
        }

        protected override UserBase ExecuteCore(ISession session)
        {
            return session.Query<UserBase>().SingleOrDefault(x => x.UserName == _username);
        }
    }
}