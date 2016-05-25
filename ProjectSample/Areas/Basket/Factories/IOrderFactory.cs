using ProjectSample.Core.Domain;

namespace ProjectSample.Areas.Basket.Factories
{
    public interface IOrderFactory
    {
        Order Create(Core.Domain.Basket basket);
    }
}