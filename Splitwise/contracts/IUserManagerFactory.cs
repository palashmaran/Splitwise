
namespace Splitwise.contracts
{
    using Splitwise.Controllers;
    using Splitwise.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IUserManagerFactory
    {
        public abstract UserManager CreateUserManager(IUser userService);
    }
}
