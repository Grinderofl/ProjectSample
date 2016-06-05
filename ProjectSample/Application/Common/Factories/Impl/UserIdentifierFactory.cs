using System.Web;
using ProjectSample.Core.Common.Models;
using ProjectSample.Core.Domain;

namespace ProjectSample.Application.Common.Factories.Impl
{
    public class UserIdentifierFactory : IIdentifierFactory<User>
    {
        public virtual Identifier CreateIdentifier()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return (Identifier) HttpContext.Current.User.Identity.Name;
            }
            return null;
        }
    }
}