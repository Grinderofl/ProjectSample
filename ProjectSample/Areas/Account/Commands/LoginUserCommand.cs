using ProjectSample.Infrastructure.Security.Domain;

namespace ProjectSample.Areas.Account.Commands
{
    public class LoginUserCommand
    {
        public LoginUserCommand(UserBase user)
        {
            User = user;
        }

        public UserBase User { get; }
    }
}