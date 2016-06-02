using System.Web.Mvc;
using AutoMapper;
using ProjectSample.Areas.Basket.Commands;
using ProjectSample.Areas.Basket.Controllers.Base;
using ProjectSample.Areas.Shared.Services;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.CommandBus;
using ProjectSample.Infrastructure.DataAccess.List;

namespace ProjectSample.Areas.Basket.Controllers
{
    public class CheckoutController : BasketControllerBase
    {
        private readonly ICommandBus _commandBus;

        public CheckoutController(ICurrentCustomerService currentCustomerService, IListService<BasketItem> listService, IMapper mapper, ICommandBus commandBus) : base(currentCustomerService, listService, mapper)
        {
            _commandBus = commandBus;
        }

        public ActionResult Index()
        {
            var listModel = CreateBasketModel();
            return View(listModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            var currentUser = CurrentCustomerService.CurrentCustomer();
            _commandBus.Send(new CheckoutCommand(currentUser));
            return View();
        }
    }
}