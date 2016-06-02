using System.Web.Mvc;
using ProjectSample.Infrastructure.CommandBus;

namespace ProjectSample.Areas.Account.Controllers
{
    public abstract class AccountControllerBase : Controller
    {
        public virtual ICommandBus Bus { get; set; }
    }
}