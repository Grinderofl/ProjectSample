using ProjectSample.Core.Domain;

namespace ProjectSample.Areas.Shared.Services
{
    public interface ICurrentUserService
    {
        User CurrentUser();
    }
}