using System.Web.Mvc;
using AutoMapper;
using ProjectSample.Areas.Basket.Controllers.Base;
using ProjectSample.Areas.Shared.Services;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.DataAccess.List;

namespace ProjectSample.Areas.Basket.Controllers
{
    public class WidgetController : BasketControllerBase
    {
        public WidgetController(ICurrentCustomerService currentCustomerService, IListService<BasketItem> listService,
            IMapper mapper) : base(currentCustomerService, listService, mapper)
        {
        }

        [ChildActionOnly]
        public ActionResult Index()
        {
            var listModel = CreateBasketModel();
            return PartialView(listModel);
        }
    }
}