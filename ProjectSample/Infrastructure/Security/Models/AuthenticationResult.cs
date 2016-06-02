using ProjectSample.Infrastructure.Security.Domain;

namespace ProjectSample.Infrastructure.Security.Models
{
    public class AuthenticationResult
    {
        public static AuthenticationResult InvalidUsername = new AuthenticationResult("Invalid username", false);
        public static AuthenticationResult InvalidPassword = new AuthenticationResult("Invalid password", false);

        private AuthenticationResult(string message, bool sucess)
        {
            Message = message;
            Authenticated = sucess;
        }

        public bool Authenticated { get; }
        public string Message { get; }
        public UserBase User { get; set; }

        public static AuthenticationResult Success(UserBase user)
            => new AuthenticationResult("Success", true) {User = user};
    }
}