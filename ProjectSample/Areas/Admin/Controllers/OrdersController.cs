using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjectSample.Areas.Admin.Models.Orders;
using ProjectSample.Core.Domain;
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
            order.Progress(OrderState.Accepted);
            SaveEntity(order);
            return RedirectToAction("Index");
        }
    }
}