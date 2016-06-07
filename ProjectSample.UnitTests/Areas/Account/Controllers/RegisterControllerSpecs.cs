using System.Web.Mvc;
using FluentAssertions.Mvc;
using Moq;
using NUnit.Framework;
using ProjectSample.Areas.Account.Commands;
using ProjectSample.Areas.Account.Controllers;
using ProjectSample.Areas.Account.Models.Register;
using ProjectSample.Areas.Account.Services;
using ProjectSample.Areas.Account.Services.Models;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.CommandBus;
using ProjectSample.Infrastructure.Security.Domain;

namespace ProjectSample.UnitTests.Areas.Account.Controllers
{
    public class RegisterControllerSpecs
    {
        public abstract class RegisterControllerContext : TestBase
        {
            protected RegisterController Controller;

            protected Mock<IRegistrationService> RegistrationServiceMock;
            protected Mock<ICommandBus> CommandBusMock;

            protected ActionResult Result;

            protected override void SharedContext()
            {
                RegistrationServiceMock = CreateDependency<IRegistrationService>();
                CommandBusMock = CreateDependency<ICommandBus>();
                Controller = new RegisterController(RegistrationServiceMock.Object)
                {
                    Bus = CommandBusMock.Object
                };
            }
        }

        public class WhenRegisteringAndUserCanBeRegistered : RegisterControllerContext
        {
            private Mock<User> _userBaseMock;
            private RegisterFields _fields;
            protected override void Context()
            {
                _fields = new RegisterFields()
                {
                    Email = "foo",
                    Password = "bar"
                };
                _userBaseMock = CreateDependency<User>();
                RegistrationServiceMock.Setup(x => x.Register(It.IsAny<RegisterFields>()))
                    .Returns(RegistrationResult.Success(_userBaseMock.Object));

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

        public class WhenRegisteringAndUserCannotBeRegistered : RegisterControllerContext
        {
            private RegisterFields _fields;

            protected override void Context()
            {
                _fields = new RegisterFields()
                {
                    Email = "foo",
                    Password = "bar"
                };
                RegistrationServiceMock.Setup(x => x.Register(It.IsAny<RegisterFields>()))
                    .Returns(RegistrationResult.DuplicateUsername);

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
                Result.Should().BeViewResult().WithDefaultViewName().ModelAs<RegisterFields>();
            }
        }
    }

    
}

