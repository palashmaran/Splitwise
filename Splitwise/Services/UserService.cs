using Splitwise.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.Services
{
    public class UserService : IUser
    {
        public static Dictionary<string, User> UserList = new Dictionary<string, User>();
        public UserService()
        {
        }

        public void AddUser(User user)
        {
            UserList.Add(user.UserId, user);
        }

        public User GetUser(string userId)
        {
            return UserList[userId];
        }
    }
}
