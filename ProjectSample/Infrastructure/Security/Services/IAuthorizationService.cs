using ProjectSample.Core.Domain.Base;

namespace ProjectSample.Infrastructure.Security.Services
{
    public interface IAuthorizationService
    {
        void SignIn(UserBase user);
        void SignOut();
    }
}