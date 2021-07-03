
namespace Splitwise.Controllers
{
    using Splitwise.contracts;
    using Splitwise.Models;
    using Splitwise.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    class UserServiceFactory : IUserServiceFactory
    {
        IUser IUserServiceFactory.CreateUserService(ServiceType uSERSERVICE)
        {
            if (uSERSERVICE == ServiceType.USERSERVICE)
                return new UserService();

            return null;
        }
    }
}
