using System.Web.Security;
using ProjectSample.Core.Domain.Base;

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