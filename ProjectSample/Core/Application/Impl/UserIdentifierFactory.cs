using System.Web;
using ProjectSample.Core.Application.Models;
using ProjectSample.Core.Domain;

namespace ProjectSample.Core.Application.Impl
{
    public class UserIdentifierFactory : IIdentifierFactory<User>
    {
        public Identifier CreateIdentifier()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return (Identifier) HttpContext.Current.User.Identity.Name;
            }
            return null;
        }
    }
}