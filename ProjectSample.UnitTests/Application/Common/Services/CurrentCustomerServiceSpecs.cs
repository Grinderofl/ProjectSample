using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjectSample.Application.Common.Factories;
using ProjectSample.Application.Common.Services;
using ProjectSample.Application.Common.Services.Impl.Base;
using ProjectSample.Core.Common.Models;
using ProjectSample.Core.Domain;
using ProjectSample.Core.Domain.Queries;
using ProjectSample.Infrastructure.DataAccess;

namespace ProjectSample.UnitTests.Application.Common.Services
{
    public class CurrentCustomerServiceSpecs
    {
        public abstract class CurrentCustomerServiceContext : TestBase
        {
            protected CurrentCustomerService Service;

            protected Mock<IIdentifierFactory<Customer>> IdentifierFactoryMock;
            protected Mock<IRepository> RepositoryMock;
            protected Mock<ICurrentUserService> CurrentUserServiceMock;

            protected Customer Result;

            protected override void SharedContext()
            {
                IdentifierFactoryMock = CreateDependency<IIdentifierFactory<Customer>>();
                RepositoryMock = CreateDependency<IRepository>();
                CurrentUserServiceMock = CreateDependency<ICurrentUserService>();


                Service = new CurrentCustomerService(RepositoryMock.Object, IdentifierFactoryMock.Object,
                    CurrentUserServiceMock.Object);
            }
        }

        public class WhenGettingCurrentCustomerAndThereIsACurrentUser : CurrentCustomerServiceContext
        {
            private Mock<Customer> _mockCustomer;

            protected override void Context()
            {
                _mockCustomer = CreateDependency<Customer>();
                var mockUser = CreateDependency<User>();
                mockUser.SetupGet(x => x.Customer).Returns(_mockCustomer.Object);
                CurrentUserServiceMock.Setup(x => x.CurrentUser()).Returns(mockUser.Object);

                Result = Service.CurrentCustomer();
            }

            [Test]
            public void should_return_customer()
            {
                Result.Should().BeSameAs(_mockCustomer.Object);
            }
        }

        public class WhenGettingCurrentCustomerAndThereIsNoCurrentUserAndCustomerDoesNotExist :
        CurrentCustomerServiceContext
        {
            private Identifier _identifier;

            protected override void Context()
            {
                _identifier = (Identifier)"123";
                IdentifierFactoryMock.Setup(x => x.CreateIdentifier()).Returns(_identifier);
                Result = Service.CurrentCustomer();
            }

            [Test]
            public void should_return_customer_with_correct_identifier()
            {
                Result.Identifier.ShouldBeEquivalentTo((string)_identifier);
            }

            [Test]
            public void should_save()
            {
                RepositoryMock.Verify(x => x.Save(It.Is<Customer>(t => t.Identifier == _identifier)));
            }
        }

        public class WhenGettingCurrentCustomerAndThereIsNoCurrentUserAndCustomerExists : CurrentCustomerServiceContext
        {
            private Mock<Customer> _mockCustomer;
            private Identifier _identifier;

            protected override void Context()
            {
                _mockCustomer = CreateDependency<Customer>();
                _identifier = (Identifier)"123";
                IdentifierFactoryMock.Setup(x => x.CreateIdentifier()).Returns(_identifier);
                RepositoryMock.Setup(x => x.Query(It.IsAny<FindCustomerByIdentityQuery>())).Returns(_mockCustomer.Object);

                Result = Service.CurrentCustomer();
            }

            [Test]
            public void should_return_customer()
            {
                Result.Should().BeSameAs(_mockCustomer.Object);
            }
        }
    }

    
}