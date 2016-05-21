using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProjectSample.Areas.Catalog.Models.Home;
using ProjectSample.Core.Domain.Queries;
using ProjectSample.Core.Infrastructure.DataAccess;

namespace ProjectSample.Areas.Catalog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public HomeController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult Index(int page = 1)
        {
            var products = _repository.Query(new FindProductsByPageQuery(page, 30));
            var productModels = _mapper.Map<IEnumerable<ProductModel>>(products);
            var model = new IndexModel()
            {
                Page = page,
                TotalItems = 30,
                Products = productModels
            };
            return View(model);
        }
    }
}