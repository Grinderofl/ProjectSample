using ProjectSample.Areas.Account.Models.Register;
using ProjectSample.Areas.Account.Services.Models;

namespace ProjectSample.Areas.Account.Services
{
    public interface IRegistrationService
    {
        RegistrationResult Register(RegisterFields fields);

    }
}