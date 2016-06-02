using ProjectSample.Core.Domain.Base;
using ProjectSample.Infrastructure.DataAccess;
using ProjectSample.Infrastructure.NHibernate.Security.Queries;
using ProjectSample.Infrastructure.Security;

namespace ProjectSample.Infrastructure.NHibernate.Security.Impl
{
    public class UserDataSource : IUserDataSource
    {
        private readonly IRepository _repository;

        public UserDataSource(IRepository repository)
        {
            _repository = repository;
        }

        public UserBase FindUserByUsername(string username)
        {
            var query = new FindUserByUsernameQuery(username);
            var user = _repository.Query(query);
            return user;
        }
    }
}