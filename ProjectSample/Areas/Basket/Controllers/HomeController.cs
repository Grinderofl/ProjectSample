using System.Web.Mvc;
using AutoMapper;
using ProjectSample.Areas.Basket.Controllers.Base;
using ProjectSample.Areas.Basket.Models;
using ProjectSample.Areas.Shared.Services;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.DataAccess.List;

namespace ProjectSample.Areas.Basket.Controllers
{
    public class HomeController : BasketControllerBase
    {


        public virtual ActionResult Index()
        {
            var listModel = CreateBasketModel();
            return View(listModel);
        }

        public HomeController(ICurrentCustomerService currentCustomerService, IListService<BasketItem> listService, IMapper mapper) : base(currentCustomerService, listService, mapper)
        {
        }
    }
}