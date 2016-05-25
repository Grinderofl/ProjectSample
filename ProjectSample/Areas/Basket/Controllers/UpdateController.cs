using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectSample.Areas.Basket.Commands;
using ProjectSample.Core.Infrastructure.CommandBus;

namespace ProjectSample.Areas.Basket.Controllers
{
    public class UpdateController : Controller
    {
        private readonly ICommandBus _commandBus;

        public UpdateController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        // GET: Basket/Update/Add/{id}
        public ActionResult Add(long id)
        {
            _commandBus.Send(new AddProductToBasketCommand(id));
            return RedirectToAction("Index", "Home", new {area = "Catalog"});
        }
    }


    public class WidgetController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}