using Moq;
using NUnit.Framework;
using ProjectSample.Core.Common.Models;
using ProjectSample.Core.Domain;

namespace ProjectSample.UnitTests.Application.Common.Services
{
    public class WhenGettingCurrentCustomerAndThereIsNoCurrentUserAndCustomerDoesNotExist :
        CurrentCustomerServiceContext
    {
        private Identifier _identifier;

        protected override void Setup()
        {
            _identifier = (Identifier) "123";
            IdentifierFactoryMock.Setup(x => x.CreateIdentifier()).Returns(_identifier);
            Result = Service.CurrentCustomer();
        }

        [Test]
        public void should_return_customer_with_correct_identifier()
        {
            Assert.AreEqual((string)_identifier, Result.Identifier);
        }

        [Test]
        public void should_save()
        {
            RepositoryMock.Verify(x => x.Save(It.Is<Customer>(t => t.Identifier == _identifier)));
        }
    }
}