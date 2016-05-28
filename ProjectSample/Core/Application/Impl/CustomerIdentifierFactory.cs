using System.Web;
using ProjectSample.Core.Application.Models;
using ProjectSample.Core.Domain;

namespace ProjectSample.Core.Application.Impl
{
    public class CustomerIdentifierFactory : IIdentifierFactory<Customer>
    {
        public Identifier CreateIdentifier() => (Identifier) HttpContext.Current.Session.SessionID;
    }
}