using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Areas.Basket.Models;
using ProjectSample.Core.Domain;
using ProjectSample.Core.Infrastructure.DataAccess.List.Mapping;

namespace ProjectSample.Areas.Basket.Mapping
{
    public class BasketItemListProfile : AbstractListProfile<BasketItem, BasketItemModel>
    {
    }
}