using Moq;
using NUnit.Framework;
using ProjectSample.Core.Common.Models;
using ProjectSample.Core.Domain;
using ProjectSample.Core.Domain.Queries;

namespace ProjectSample.UnitTests.Application.Common.Services
{
    public class WhenGettingCurrentCustomerAndThereIsNoCurrentUserAndCustomerExists : CurrentCustomerServiceContext
    {
        private Mock<Customer> _mockCustomer;
        private Identifier _identifier;

        protected override void Setup()
        {
            _mockCustomer = CreateDependency<Customer>();
            _identifier = (Identifier) "123";
            IdentifierFactoryMock.Setup(x => x.CreateIdentifier()).Returns(_identifier);
            RepositoryMock.Setup(x => x.Query(It.IsAny<FindCustomerByIdentityQuery>())).Returns(_mockCustomer.Object);

            Result = Service.CurrentCustomer();
        }

        [Test]
        public void should_return_customer()
        {
            Assert.AreSame(Result, _mockCustomer.Object);
        }
    }
}