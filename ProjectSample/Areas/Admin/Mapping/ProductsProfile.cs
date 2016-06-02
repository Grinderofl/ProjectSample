using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Areas.Admin.Models;
using ProjectSample.Areas.Admin.Models.Products;
using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.AutoMapper;

namespace ProjectSample.Areas.Admin.Mapping
{
    public class ProductsProfile : EntityProfile<Product, ProductViewModel, ProductFields, ProductLineItemModel>
    {
    }
}