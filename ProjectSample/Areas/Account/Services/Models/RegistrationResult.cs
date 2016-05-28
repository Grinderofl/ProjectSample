using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSample.Areas.Account.Services.Models
{
    public class RegistrationResult
    {
        public static RegistrationResult DuplicateUsername = new RegistrationResult("Duplicate Username", false);
        public static RegistrationResult Success = new RegistrationResult("Success", true);

        private RegistrationResult(string message, bool success)
        {
            Registered = success;
            Message = message;
        }
        public string Message { get; }
        public bool Registered { get; }
    }
}