using ProjectSample.Areas.Admin.Models.Orders;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.AutoMapper;

namespace ProjectSample.Areas.Admin.Mapping
{
    public class OrdersProfile : EntityProfile<Order, OrderViewModel, OrderFields, OrderLineItem>
    {
    }
}