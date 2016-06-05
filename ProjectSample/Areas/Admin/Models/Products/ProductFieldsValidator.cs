using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace ProjectSample.Areas.Admin.Models.Products
{
    public class ProductFieldsValidator : AbstractValidator<ProductFields>
    {
        public ProductFieldsValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter the product name");
        }
    }
}