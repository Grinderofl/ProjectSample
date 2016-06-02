using ProjectSample.Infrastructure.Security.Models;

namespace ProjectSample.Infrastructure.Security.Services
{
    public interface IAuthenticationService
    {
        AuthenticationResult Authenticate(string username, string password);
    }
}