using System.Web;
using ProjectSample.Areas.Shared.Models;
using ProjectSample.Core.Domain;

namespace ProjectSample.Areas.Shared.Factories.Impl
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