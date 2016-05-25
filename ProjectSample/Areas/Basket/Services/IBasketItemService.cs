using System.Collections.Generic;
using ProjectSample.Core.Domain;
using ProjectSample.Core.Infrastructure.DataAccess.List;

namespace ProjectSample.Areas.Basket.Services
{
    public interface IBasketItemListService
    {
        ListResult<BasketItem> ItemsForCustomer(Customer customer);
    }
}