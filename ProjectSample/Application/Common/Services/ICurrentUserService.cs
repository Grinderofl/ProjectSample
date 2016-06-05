using ProjectSample.Core.Domain;

namespace ProjectSample.Application.Common.Services
{
    public interface ICurrentUserService
    {
        User CurrentUser();
    }
}