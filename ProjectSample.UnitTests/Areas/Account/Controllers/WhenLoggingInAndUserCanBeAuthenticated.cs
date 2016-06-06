using FluentAssertions.Mvc;
using Moq;
using NUnit.Framework;
using ProjectSample.Areas.Account.Commands;
using ProjectSample.Areas.Account.Models.Login;
using ProjectSample.Infrastructure.Security.Domain;
using ProjectSample.Infrastructure.Security.Models;

namespace ProjectSample.UnitTests.Areas.Account.Controllers
{
    public class WhenLoggingInAndUserCanBeAuthenticated : LoginControllerContext
    {
        private Mock<UserBase> _userBaseMock;
        private LoginFields _fields;
        protected override void Setup()
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
}