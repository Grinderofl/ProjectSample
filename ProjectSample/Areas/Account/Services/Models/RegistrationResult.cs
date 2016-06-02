﻿using ProjectSample.Infrastructure.Security.Domain;

namespace ProjectSample.Areas.Account.Services.Models
{
    public class RegistrationResult
    {
        public static RegistrationResult DuplicateUsername = new RegistrationResult("Duplicate Username", false);

        private RegistrationResult(string message, bool success)
        {
            Registered = success;
            Message = message;
        }

        public string Message { get; }
        public bool Registered { get; }
        public UserBase User { get; set; }

        public static RegistrationResult Success(UserBase user) => new RegistrationResult("Success", true)
        {
            User = user
        };
    }
}