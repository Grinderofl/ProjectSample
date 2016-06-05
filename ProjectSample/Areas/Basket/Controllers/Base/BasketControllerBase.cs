using System.Web.Mvc;
using AutoMapper;
using ProjectSample.Application.Common.Services;
using ProjectSample.Areas.Basket.Models;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.DataAccess.List;
using ProjectSample.Infrastructure.DataAccess.List.Models;

namespace ProjectSample.Areas.Basket.Controllers.Base
{
    public class BasketControllerBase : Controller
    {
        private readonly IListService<BasketItem> _listService;
        private readonly IMapper _mapper;
        protected readonly ICurrentCustomerService CurrentCustomerService;

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