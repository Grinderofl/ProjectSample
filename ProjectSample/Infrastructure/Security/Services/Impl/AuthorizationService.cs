using System;
using System.Web;
using System.Web.Security;
using ProjectSample.Infrastructure.Security.Domain;

namespace ProjectSample.Infrastructure.Security.Services.Impl
{
    public class AuthorizationService : IAuthorizationService
    {
        public void SignIn(UserBase user)
        {
            FormsAuthentication.SetAuthCookie(user.UserName, true);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}