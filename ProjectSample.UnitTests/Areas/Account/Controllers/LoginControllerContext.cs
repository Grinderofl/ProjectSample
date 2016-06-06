using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using ProjectSample.Areas.Account.Controllers;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.CommandBus;
using ProjectSample.Infrastructure.Security.Services;

namespace ProjectSample.UnitTests.Areas.Account.Controllers
{
    public class LoginControllerContext : TestBase
    {
        protected LoginController Controller;
        
        protected Mock<IAuthenticationService> AuthServiceMock;
        protected Mock<ICommandBus> CommandBusMock;

        protected ActionResult Result;

        protected override void SharedContext()
        {
            AuthServiceMock = CreateDependency<IAuthenticationService>();
            CommandBusMock = CreateDependency<ICommandBus>();
            Controller = new LoginController(AuthServiceMock.Object)
            {
                Bus = CommandBusMock.Object
            };
        }
    }
}

