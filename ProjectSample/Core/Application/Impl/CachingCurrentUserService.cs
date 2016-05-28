using ProjectSample.Core.Application.Impl.Base;
using ProjectSample.Core.Domain;
using ProjectSample.Core.Infrastructure.DataAccess;

namespace ProjectSample.Core.Application.Impl
{
    public class CachingCurrentUserService : CurrentUserService
    {
        public CachingCurrentUserService(IRepository repository, IIdentifierFactory<User> identifierFactory) : base(repository, identifierFactory)
        {
        }

        private User _cachedUser;

        public override User CurrentUser()
            => _cachedUser ?? (_cachedUser = base.CurrentUser());
    }
}