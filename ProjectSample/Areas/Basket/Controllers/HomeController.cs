using System.Web.Mvc;
using AutoMapper;
using ProjectSample.Application.Common.Services;
using ProjectSample.Areas.Basket.Controllers.Base;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.DataAccess.List;

namespace ProjectSample.Areas.Basket.Controllers
{
    public class HomeController : BasketControllerBase
    {
        public HomeController(ICurrentCustomerService currentCustomerService, IListService<BasketItem> listService, IMapper mapper) : base(currentCustomerService, listService, mapper)
        {
        }


        public virtual ActionResult Index()
        {
            var listModel = CreateBasketModel();
            return View(listModel);
        }
    }
}