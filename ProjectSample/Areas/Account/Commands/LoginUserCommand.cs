using ProjectSample.Core.Domain;
using ProjectSample.Infrastructure.Security.Domain;

namespace ProjectSample.Areas.Account.Commands
{
    public class LoginUserCommand
    {
        public LoginUserCommand(User user)
        {
            User = user;
        }

        public User User { get; }
    }
}