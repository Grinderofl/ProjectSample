using System.Web;
using ProjectSample.Areas.Shared.Models;
using ProjectSample.Core.Domain;

namespace ProjectSample.Areas.Shared.Factories.Impl
{
    public class CustomerIdentifierFactory : IIdentifierFactory<Customer>
    {
        public virtual Identifier CreateIdentifier() => (Identifier) HttpContext.Current.Session.SessionID;
    }
}