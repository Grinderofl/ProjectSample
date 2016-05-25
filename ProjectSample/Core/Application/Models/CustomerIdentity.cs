using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSample.Core.Application.Models
{
    public class CustomerIdentity
    {
        private readonly string _identity;

        private CustomerIdentity(string identity)
        {
            _identity = identity;
        }

        public static explicit operator CustomerIdentity(string value) => new CustomerIdentity(value);
        public static implicit operator string(CustomerIdentity @this) => @this._identity;
    }
}