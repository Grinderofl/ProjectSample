using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        [ChildActionOnly]
        public ActionResult Index()
        {
            var listModel = CreateBasketModel();
            return PartialView(listModel);
        }

        public WidgetController(ICurrentCustomerService currentCustomerService, IListService<BasketItem> listService,
            IMapper mapper) : base(currentCustomerService, listService, mapper)
        {
        }
    }
}