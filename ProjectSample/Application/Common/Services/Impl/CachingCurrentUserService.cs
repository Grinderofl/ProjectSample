using ProjectSample.Application.Common.Factories;
using ProjectSample.Application.Common.Services.Impl.Base;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.DataAccess;

namespace ProjectSample.Application.Common.Services.Impl
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