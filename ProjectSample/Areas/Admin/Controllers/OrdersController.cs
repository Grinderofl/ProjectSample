using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjectSample.Areas.Admin.Commands;
using ProjectSample.Areas.Admin.Models.Orders;
using ProjectSample.Core.Domain;
using ProjectSample.Core.Domain.Extensions;
using ProjectSample.Core.Infrastructure.DataAccess;
using ProjectSample.Core.Infrastructure.Mvc.Controllers;

namespace ProjectSample.Areas.Admin.Controllers
{
    public class OrdersController : EntityController<Order, OrderViewModel, OrderFields, OrderLineItem, long>
    {
        public OrdersController(IMapper mapper, IRepository repository) : base(mapper, repository)
        {
        }

        protected override IEnumerable<string> GetHeaders()
        {
            yield return "Id";
            yield return "Total";
            yield return "State";
            yield return "";
        }

        public override ActionResult Edit(long id)
        {
            return RedirectToAction("Index");
        }

        public override ActionResult Create()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Accept(long id)
        {
            var order = FindEntity(id);
            if (order.IsPlaced())
            {
                order.Accept();
                SaveEntity(order);
                SetSuccess("The order has been accepted.");
            }
            else
            {
                SetError("The order cannot be accepted.");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Ship(long id)
        {
            var order = FindEntity(id);
            if (order.IsAccepted())
            {
                Bus.Send(new ShipOrderCommand(order));
                SetSuccess("Order has been shipped.");
            }
            else
            {
                SetError("Order cannot be shipped.");
            }
            return RedirectToAction("Index");
        }
    }
}