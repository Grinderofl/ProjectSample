using System.Web;
using ProjectSample.Core.Common.Models;
using ProjectSample.Core.Domain;

namespace ProjectSample.Application.Common.Factories.Impl
{
    public class CustomerIdentifierFactory : IIdentifierFactory<Customer>
    {
        public virtual Identifier CreateIdentifier() => (Identifier) HttpContext.Current.Session.SessionID;
    }
}