using ProjectSample.Infrastructure.Security.Models;

namespace ProjectSample.Infrastructure.Security.Services.Impl
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserDataSource _userDataSource;
        private readonly ICryptoService _cryptoService;

        public AuthenticationService(IUserDataSource userDataSource, ICryptoService cryptoService)
        {
            _userDataSource = userDataSource;
            _cryptoService = cryptoService;
        }

        public AuthenticationResult Authenticate(string username, string password)
        {
            var user = _userDataSource.FindUserByUsername(username);

            if (user == null)
            {
                return AuthenticationResult.InvalidUsername;
            }

            if (!_cryptoService.VerifyHash(user.PasswordHash, password))
            {
                return AuthenticationResult.InvalidPassword;
            }

            return AuthenticationResult.Success(user);
        }
    }
}