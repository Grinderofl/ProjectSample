using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProjectSample.Areas.Admin.Models;
using ProjectSample.Core.Domain;
using ProjectSample.Core.Infrastructure.DataAccess;
using ProjectSample.Core.Infrastructure.Mvc.Controllers;

namespace ProjectSample.Areas.Admin.Controllers
{
    public class ProductController : EntityController<Product, ProductViewModel, ProductFields, ProductLineItemModel,long>
    {
        public ProductController(IMapper mapper, IRepository repository) : base(mapper, repository)
        {
        }

        protected override IEnumerable<string> GetHeaders()
        {
            yield return "Id";
            yield return "Name";
        }
    }
}
