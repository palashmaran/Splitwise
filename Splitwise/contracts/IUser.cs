
namespace Splitwise.Services
{
    using Splitwise.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IUser
    {
        public static Dictionary<string, User> UserList { get; }
        public void AddUser(User user);
        public User GetUser(string userId);
    }
}
