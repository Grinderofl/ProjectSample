using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Core.Domain.Base;

namespace ProjectSample.Core.Infrastructure.Identity.Models
{
    public class AuthenticationResult
    {
        public static AuthenticationResult InvalidUsername = new AuthenticationResult("Invalid username", false);
        public static AuthenticationResult InvalidPassword = new AuthenticationResult("Invalid password", false);

        private AuthenticationResult(string message, bool sucess)
        {
            Message = message;
            Sucess = sucess;
        }

        public static AuthenticationResult Success(UserBase user)
            => new AuthenticationResult("Success", true) {User = user};

        public bool Sucess { get; }
        public string Message { get; }
        public UserBase User { get; set; }
    }
}