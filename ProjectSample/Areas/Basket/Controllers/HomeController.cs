using System.Web.Mvc;
using AutoMapper;
using ProjectSample.Areas.Basket.Controllers.Base;
using ProjectSample.Areas.Basket.Models;
using ProjectSample.Core.Application;
using ProjectSample.Core.Domain;
using ProjectSample.Core.Infrastructure.DataAccess.List;
using ProjectSample.Core.Infrastructure.DataAccess.List.Models;

namespace ProjectSample.Areas.Basket.Controllers
{
    public class HomeController : BasketControllerBase
    {


        public virtual ActionResult Index()
        {
            var listModel = CreateBasketModel();
            return View(listModel);
        }

        public HomeController(ICurrentUserService currentUserService, IListService<BasketItem> listService, IMapper mapper) : base(currentUserService, listService, mapper)
        {
        }
    }
}