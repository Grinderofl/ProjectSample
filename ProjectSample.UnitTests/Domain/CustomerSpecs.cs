using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using ProjectSample.Core.Domain;

namespace ProjectSample.UnitTests.Domain
{
    public class CustomerSpecs
    {
        public abstract class CustomerContext : TestBase
        {
            
        }

        public class WhenTransferringBasketToANewCustomer : CustomerContext
        {
            private Customer _originalCustomer;
            private Customer _customerToTransfer;
            
            protected override void Context()
            {
                _originalCustomer = new Customer();
                _customerToTransfer = new Customer();
                var product1 = new Product()
                {
                    Id = 1,
                    Name = "Foo"
                };

                var product2 = new Product()
                {
                    Id = 2,
                    Name = "Bar"
                };
                //var mockProduct1 = CreateDependency<Product>();
                //mockProduct1.SetupGet(x => x.Id).Returns(1);

                //var mockProduct2 = CreateDependency<Product>();
                //mockProduct2.SetupGet(x => x.Id).Returns(2);
                _customerToTransfer.Basket.Add(product1, 2);
                _customerToTransfer.Basket.Add(product2, 3);
            }

            protected override void Because()
            {
                _originalCustomer.TransferBasket(_customerToTransfer);
            }

            [Test]
            public void should_contain_right_number_of_products()
            {
                _originalCustomer.Basket.Items.Count().Should().Be(2);
            }

            [Test]
            public void should_contain_right_number_of_items()
            {
                _originalCustomer.Basket.Items.Sum(x => x.Quantity).Should().Be(5);
            }
        }

    }
}
