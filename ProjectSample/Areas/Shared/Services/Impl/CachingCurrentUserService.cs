using ProjectSample.Areas.Shared.Factories;
using ProjectSample.Areas.Shared.Services.Impl.Base;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.DataAccess;

namespace ProjectSample.Areas.Shared.Services.Impl
{
    public class CachingCurrentUserService : CurrentUserService
    {
        private User _cachedUser;

        public CachingCurrentUserService(IRepository repository, IIdentifierFactory<User> identifierFactory) : base(repository, identifierFactory)
        {
        }

        public override User CurrentUser()
            => _cachedUser ?? (_cachedUser = base.CurrentUser());
    }
}