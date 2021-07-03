using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.Models
{
    public class Group
    {
        private string groupId;
        private string name;
        private List<User> members;
        public Group(string groupId, string name)
        {
            this.GroupId = groupId;
            this.Name = name;
            Members = new List<User>();
        }

        public string GroupId { get => groupId; set => groupId = value; }
        public string Name { get => name; set => name = value; }
        internal List<User> Members { get => members; set => members = value; }

        public void AddMember(User user)
        {
            Members.Add(user);
        }
    }
}
