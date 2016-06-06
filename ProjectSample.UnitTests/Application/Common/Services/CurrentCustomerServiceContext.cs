using Moq;
using ProjectSample.Application.Common.Factories;
using ProjectSample.Application.Common.Services;
using ProjectSample.Application.Common.Services.Impl.Base;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.DataAccess;

namespace ProjectSample.UnitTests.Application.Common.Services
{
    public class CurrentCustomerServiceContext : TestBase
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
}