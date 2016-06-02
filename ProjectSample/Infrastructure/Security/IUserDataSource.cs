using ProjectSample.Core.Domain.Base;

namespace ProjectSample.Infrastructure.Security
{
    public interface IUserDataSource
    {
        UserBase FindUserByUsername(string username);
    }
}