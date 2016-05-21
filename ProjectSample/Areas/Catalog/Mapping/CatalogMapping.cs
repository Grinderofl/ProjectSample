using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ProjectSample.Areas.Catalog.Models.Home;
using ProjectSample.Core.Domain;

namespace ProjectSample.Areas.Catalog.Mapping
{
    public class CatalogProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Product, ProductModel>();
        }
    }
}