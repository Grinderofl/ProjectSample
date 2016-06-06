using FluentAssertions.Mvc;
using Moq;
using NUnit.Framework;
using ProjectSample.Areas.Account.Commands;
using ProjectSample.Areas.Account.Models.Login;
using ProjectSample.Infrastructure.Security.Models;

namespace ProjectSample.UnitTests.Areas.Account.Controllers
{
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