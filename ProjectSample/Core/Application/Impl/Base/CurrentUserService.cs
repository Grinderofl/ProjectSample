using ProjectSample.Core.Domain;
using ProjectSample.Core.Infrastructure.DataAccess;
using ProjectSample.Core.Infrastructure.NHibernate.Identity.Queries;

namespace ProjectSample.Core.Application.Impl.Base
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IRepository _repository;
        private readonly IIdentifierFactory<User> _identifierFactory;

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