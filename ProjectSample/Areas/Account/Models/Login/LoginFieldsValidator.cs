using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace ProjectSample.Areas.Account.Models.Login
{
    public class LoginFieldsValidator : AbstractValidator<LoginFields>
    {
        public LoginFieldsValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Please enter valid e-mail address");
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}