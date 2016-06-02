using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.DataAccess.List.Models;

namespace ProjectSample.Areas.Basket.Services
{
    public interface IBasketItemListService
    {
        ListResult<BasketItem> ItemsForCustomer(Customer customer);
    }
}