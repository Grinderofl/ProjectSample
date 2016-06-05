using ProjectSample.Application.Common.Factories;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.DataAccess;
using ProjectSample.Infrastructure.NHibernate.Security.Queries;

namespace ProjectSample.Application.Common.Services.Impl.Base
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IIdentifierFactory<User> _identifierFactory;
        private readonly IRepository _repository;

        public CurrentUserService(IRepository repository, IIdentifierFactory<User> identifierFactory)
        {
            _repository = repository;
            _identifierFactory = identifierFactory;
        }

        public virtual User CurrentUser()
        {
            var identifier = _identifierFactory.CreateIdentifier();
            if (identifier == null)
                return null;

            var user = (User)_repository.Query(new FindUserByUsernameQuery(identifier));

            return user;
        }
    }
}