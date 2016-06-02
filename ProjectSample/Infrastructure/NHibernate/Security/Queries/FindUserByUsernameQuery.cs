using System.Linq;
using NHibernate;
using NHibernate.Linq;
using ProjectSample.Infrastructure.NHibernate.Queries;
using ProjectSample.Infrastructure.Security.Domain;

namespace ProjectSample.Infrastructure.NHibernate.Security.Queries
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