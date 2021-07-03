
namespace Splitwise.Controllers
{
    using Splitwise.contracts;
    using Splitwise.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    class UserManagerFactory : IUserManagerFactory
    {
        public UserManager CreateUserManager(IUser userService)
        {
            return new UserManager(userService);
        }
    }
}
