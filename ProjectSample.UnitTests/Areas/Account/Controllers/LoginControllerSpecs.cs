using System.Web.Mvc;
using FluentAssertions.Mvc;
using Moq;
using NUnit.Framework;
using ProjectSample.Areas.Account.Commands;
using ProjectSample.Areas.Account.Controllers;
using ProjectSample.Areas.Account.Models.Login;
using ProjectSample.Infrastructure.CommandBus;
using ProjectSample.Infrastructure.Security.Domain;
using ProjectSample.Infrastructure.Security.Models;
using ProjectSample.Infrastructure.Security.Services;

namespace ProjectSample.UnitTests.Areas.Account.Controllers
{
    public class LoginControllerSpecs
    {
        public abstract class LoginControllerContext : TestBase
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

        public class WhenLoggingInAndUserCanBeAuthenticated : LoginControllerContext
        {
            private Mock<UserBase> _userBaseMock;
            private LoginFields _fields;
            protected override void Context()
            {
                _fields = new LoginFields()
                {
                    Email = "foo",
                    Password = "bar"
                };
                _userBaseMock = CreateDependency<UserBase>();
                var authResult = AuthenticationResult.Success(_userBaseMock.Object);
                AuthServiceMock.Setup(x => x.Authenticate(_fields.Email, _fields.Password)).Returns(authResult);

                Result = Controller.Index(_fields);
            }

            [Test]
            public void should_send_login_command()
            {
                CommandBusMock.Verify(x => x.Send(It.Is<LoginUserCommand>(l => l.User == _userBaseMock.Object)), Times.Once);
            }

            [Test]
            public void should_redirect()
            {
                Result.Should().BeRedirectToRouteResult().WithController("Home").WithArea("Catalog").WithAction("Index");
            }
        }

        public class WhenLoggingInAndUserCannotBeAuthenticated : LoginControllerContext
        {
            private LoginFields _fields;

            protected override void Context()
            {
                _fields = new LoginFields()
                {
                    Email = "foo",
                    Password = "bar"
                };
                AuthServiceMock.Setup(x => x.Authenticate(_fields.Email, _fields.Password))
                    .Returns(AuthenticationResult.InvalidUsername);

                Result = Controller.Index(_fields);
            }

            [Test]
            public void should_not_send_login_command()
            {
                CommandBusMock.Verify(x => x.Send(It.IsAny<LoginUserCommand>()), Times.Never);
            }

            [Test]
            public void should_return_view()
            {
                Result.Should().BeViewResult().WithDefaultViewName().ModelAs<LoginFields>();
            }
        }
    }

    
}

