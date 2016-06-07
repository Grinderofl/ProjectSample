using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSample.Core.Domain;

namespace ProjectSample.Areas.Account.Commands
{
    public class TransferBasketCommand
    {
        public User User { get; }
        public Customer TransferFrom { get; }

        public TransferBasketCommand(User user, Customer transferFrom)
        {
            User = user;
            TransferFrom = transferFrom;
        }
    }
}