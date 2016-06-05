using FluentValidation;
using ProjectSample.Areas.Account.Models.Login;

namespace ProjectSample.Areas.Account.Models.Register
{
    public class RegisterFieldsValidator : AbstractValidator<RegisterFields>
    {
        public RegisterFieldsValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Please enter valid e-mail address");
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}