using ProjectSample.Infrastructure.Security.Domain;

namespace ProjectSample.Infrastructure.Security.Services
{
    public interface IAuthorizationService
    {
        void SignIn(UserBase user);
        void SignOut();
    }
}