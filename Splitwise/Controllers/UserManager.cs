
namespace Splitwise.Controllers
{
    using Splitwise.Models;
    using Splitwise.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserManager
    {
        private IUser userService;

        public UserManager(IUser userService)
        {
            this.userService = userService;
        }

        public void AddUser(User user)
        {
            userService.AddUser(user);
        }

        public User GetUser(string userId)
        {
            return userService.GetUser(userId);
        }
    }
}
