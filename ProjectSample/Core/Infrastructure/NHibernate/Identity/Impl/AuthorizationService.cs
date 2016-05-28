using System;
using System.Web.Security;
using ProjectSample.Core.Domain.Base;
using ProjectSample.Core.Infrastructure.Identity;

namespace ProjectSample.Core.Infrastructure.NHibernate.Identity.Impl
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