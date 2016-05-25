using System.Web;
using ProjectSample.Core.Application.Models;

namespace ProjectSample.Core.Application.Impl
{
    public class CustomerIdentityFactory : ICustomerIdentityFactory
    {
        public CustomerIdentity CreateIdentity() => (CustomerIdentity) HttpContext.Current.Session.SessionID;
    }
}