using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProjectSample.Areas.Basket.Models;
using ProjectSample.Core.Application;
using ProjectSample.Core.Domain;
using ProjectSample.Core.Infrastructure.DataAccess.List;
using ProjectSample.Core.Infrastructure.DataAccess.List.Models;

namespace ProjectSample.Areas.Basket.Controllers.Base
{
    public class BasketControllerBase : Controller
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IListService<BasketItem> _listService;
        private readonly IMapper _mapper;

        public BasketControllerBase(ICurrentUserService currentUserService, IListService<BasketItem> listService, IMapper mapper)
        {
            _currentUserService = currentUserService;
            _listService = listService;
            _mapper = mapper;
        }

        protected virtual ListModel<BasketItemModel> CreateBasketModel()
        {
            var customer = _currentUserService.ActiveCustomer();
            var pageDescriptor = new PageDescriptor<BasketItem>();
            pageDescriptor.SortProperty = x => x.Id;
            pageDescriptor.AddSearchItem(x => x.Basket.Customer == customer);
            var listResult = _listService.GetListResult(pageDescriptor);
            var listModel = _mapper.Map<ListModel<BasketItemModel>>(listResult);
            return listModel;
        }
    }
}