using ProjectSample.Core.Domain.Base;

namespace ProjectSample.Core.Infrastructure.Identity
{
    public interface IAuthorizationService
    {
        void SignIn(UserBase user);
        void SignOut();
    }
}