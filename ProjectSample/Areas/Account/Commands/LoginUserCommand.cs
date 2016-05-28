using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Core.Domain.Base;

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