using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProjectSample.Areas.Admin.Models;
using ProjectSample.Areas.Admin.Models.Products;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.DataAccess;
using ProjectSample.Infrastructure.Mvc.Controllers;

namespace ProjectSample.Areas.Admin.Controllers
{
    public class ProductsController : EntityController<Product, ProductViewModel, ProductFields, ProductLineItemModel,long>
    {
        public ProductsController(IMapper mapper, IRepository repository) : base(mapper, repository)
        {
        }

        protected override IEnumerable<string> GetHeaders()
        {
            yield return "Id";
            yield return "Name";
        }
    }
}
