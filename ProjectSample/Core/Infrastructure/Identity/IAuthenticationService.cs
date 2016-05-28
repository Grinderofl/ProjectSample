using ProjectSample.Core.Infrastructure.Identity.Models;

namespace ProjectSample.Core.Infrastructure.Identity
{
    public interface IAuthenticationService
    {
        AuthenticationResult Authenticate(string username, string password);
    }
}