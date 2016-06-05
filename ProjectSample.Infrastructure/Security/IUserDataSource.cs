using ProjectSample.Infrastructure.Security.Domain;

namespace ProjectSample.Infrastructure.Security
{
    public interface IUserDataSource
    {
        UserBase FindUserByUsername(string username);
    }
}