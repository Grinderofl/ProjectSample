using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjectSample.Application.Common.Services;
using ProjectSample.Areas.Account.Models.Register;
using ProjectSample.Areas.Account.Services.Impl;
using ProjectSample.Areas.Account.Services.Models;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.DataAccess;
using ProjectSample.Infrastructure.NHibernate.Security.Queries;
using ProjectSample.Infrastructure.Security.Domain;
using ProjectSample.Infrastructure.Security.Services;
using ProjectSample.Infrastructure.Security.Services.Impl;

namespace ProjectSample.UnitTests.Areas.Account.Services
{
    public class RegistrationServiceSpecs
    {
        public class RegistrationServiceContext : TestBase
        {
            protected ICryptoService CryptoService;
            protected Mock<ICurrentCustomerService> CurrentCustomerServiceMock;
            protected Mock<IRepository> RepositoryMock;

            protected RegistrationService Service;
            protected RegistrationResult Result;

            protected RegisterFields Fields;

            protected override void SharedContext()
            {
                RepositoryMock = CreateDependency<IRepository>();
                CurrentCustomerServiceMock = CreateDependency<ICurrentCustomerService>();
                CryptoService = new CryptoService();

                Fields = new RegisterFields()
                {
                    Email = "Foo@bar.com",
                    Password = "foobar"
                };

                Service = new RegistrationService(RepositoryMock.Object, CurrentCustomerServiceMock.Object,
                    CryptoService);
            }

            protected override void Because()
            {
                Result = Service.Register(Fields);
            }
        }

        public class WhenRegisteringAndUserAlreadyExists : RegistrationServiceContext
        {
            private Mock<User> _userMock;
            protected override void Context()
            {
                _userMock = CreateDependency<User>();
                RepositoryMock.Setup(x => x.Query(It.IsAny<FindUserByUsernameQuery>())).Returns(_userMock.Object);
            }

            [Test]
            public void should_return_duplicate_username_result()
            {
                Result.Should().BeSameAs(RegistrationResult.DuplicateUsername);
            }
        }

        public class WhenRegisteringAndUserDoesNotExist : RegistrationServiceContext
        {
            private Mock<Customer> _customerMock;
            protected override void Context()
            {
                _customerMock = CreateDependency<Customer>();
                CurrentCustomerServiceMock.Setup(x => x.CurrentCustomer()).Returns(_customerMock.Object);
            }

            [Test]
            public void should_save()
            {
                RepositoryMock.Verify(x => x.Save(It.IsAny<User>()), Times.Once);
            }

            [Test]
            public void should_return_success()
            {
                Result.Registered.Should().BeTrue();
            }

            [Test]
            public void should_set_properties()
            {
                Result.User.Role.Should().Be(Role.User);
                Result.User.PasswordHash.Should().NotBeNullOrWhiteSpace();
                Result.User.UserName.Should().BeEquivalentTo(Fields.Email);
            }
        }
    }
}
