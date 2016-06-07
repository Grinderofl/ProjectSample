using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NHibernate.Linq;
using NUnit.Framework;
using ProjectSample.Application.Common.Services;
using ProjectSample.Areas.Account.Models.Register;
using ProjectSample.Areas.Account.Services.Impl;
using ProjectSample.Areas.Account.Services.Models;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.Security.Domain;
using ProjectSample.Infrastructure.Security.Services;
using ProjectSample.Infrastructure.Security.Services.Impl;

namespace ProjectSample.IntegrationTests.Areas.Account.Services
{
    public class RegistrationServiceSpecs
    {
        public abstract class RegistrationServiceContext : IntegrationTestBase
        {
            protected RegistrationService Service;

            protected ICryptoService CryptoService;
            protected Mock<ICurrentCustomerService> CurrentCustomerServiceMock;

            protected RegistrationResult Result;
            protected RegisterFields Fields;

            protected override void SharedContext()
            {
                CryptoService = new CryptoService();
                CurrentCustomerServiceMock = CreateDependency<ICurrentCustomerService>();
                Fields = new RegisterFields()
                {
                    Email = "Foo@bar.com",
                    Password = "foobar"
                };
                Service = new RegistrationService(Repository, CurrentCustomerServiceMock.Object, CryptoService);
            }

            protected override void Because()
            {
                Result = Service.Register(Fields);
            }
        }

        public class WhenRegisteringAndUserAlreadyExists : RegistrationServiceContext
        {
            protected override void Context()
            {
                var user = new User()
                {
                    Role = Role.User,
                    UserName = "Foo@bar.com"
                };
                Save((UserBase)user);
            }

            [Test]
            public void should_return_duplicate_username_result()
            {
                Result.Should().BeSameAs(RegistrationResult.DuplicateUsername);
            }
        }

        public class WhenRegisteringAndUserDoesNotExist : RegistrationServiceContext
        {
            private Customer _customer;
            protected override void Context()
            {
                _customer = new Customer()
                {
                    Identifier = "123"
                };
                CurrentCustomerServiceMock.Setup(x => x.CurrentCustomer()).Returns(_customer);
            }

            [Test]
            public void should_save()
            {
                var user = Session.Query<User>().SingleOrDefault();
                user.Should().NotBeNull();
                user.UserName.Should().BeEquivalentTo(Fields.Email);
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
