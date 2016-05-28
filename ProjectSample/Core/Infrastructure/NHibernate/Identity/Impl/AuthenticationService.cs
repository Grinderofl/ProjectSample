using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Core.Infrastructure.DataAccess;
using ProjectSample.Core.Infrastructure.Identity;
using ProjectSample.Core.Infrastructure.Identity.Models;
using ProjectSample.Core.Infrastructure.NHibernate.Identity.Queries;
using ProjectSample.Core.Infrastructure.Security;

namespace ProjectSample.Core.Infrastructure.NHibernate.Identity.Impl
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository _repository;
        private readonly ICryptoService _cryptoService;

        public AuthenticationService(IRepository repository, ICryptoService cryptoService)
        {
            _repository = repository;
            _cryptoService = cryptoService;
        }

        public AuthenticationResult Authenticate(string username, string password)
        {
            var query = new FindUserByUsernameQuery(username);
            var user = _repository.Query(query);

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