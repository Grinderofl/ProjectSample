using System.Web;
using ProjectSample.EF.Core.Domain;
using ProjectSample.EF.Infrastructure.Common.Models;

namespace ProjectSample.EF.Application.Common.Factories.Impl
{
    public class CustomerIdentifierFactory : IIdentifierFactory<Customer>
    {
        public virtual Identifier CreateIdentifier() => (Identifier) HttpContext.Current.Session.SessionID;
    }
}