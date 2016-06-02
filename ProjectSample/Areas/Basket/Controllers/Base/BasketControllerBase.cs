using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProjectSample.Areas.Basket.Models;
using ProjectSample.Areas.Shared.Services;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.DataAccess.List;
using ProjectSample.Infrastructure.DataAccess.List.Models;

namespace ProjectSample.Areas.Basket.Controllers.Base
{
    public class BasketControllerBase : Controller
    {
        protected readonly ICurrentCustomerService CurrentCustomerService;
        private readonly IListService<BasketItem> _listService;
        private readonly IMapper _mapper;

        public BasketControllerBase(ICurrentCustomerService currentCustomerService, IListService<BasketItem> listService, IMapper mapper)
        {
            CurrentCustomerService = currentCustomerService;
            _listService = listService;
            _mapper = mapper;
        }

        protected virtual ListModel<BasketItemModel> CreateBasketModel()
        {
            var customer = CurrentCustomerService.CurrentCustomer();
            var pageDescriptor = new EntityPageDescriptor<BasketItem>();
            pageDescriptor.AddSearchItem(x => x.Basket.Customer == customer);
            var listResult = _listService.GetListResult(pageDescriptor);
            var listModel = _mapper.Map<ListModel<BasketItemModel>>(listResult);
            return listModel;
        }
    }
}