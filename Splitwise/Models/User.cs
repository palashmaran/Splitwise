using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.Models
{
    public class User
    {
        private string userId;
        private string name;
        private string email;
        private string phonenumber;

        public User(string userId, string name, string email, string phonenumber)
        {
            this.UserId = userId;
            this.Name = name;
            this.Email = email;
            this.Phonenumber = phonenumber;
        }

        public string UserId { get => userId; set => userId = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
    }
}
