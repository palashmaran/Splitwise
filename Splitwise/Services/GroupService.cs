using Splitwise.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.Services
{
    public class GroupService : IGroup
    {
        Dictionary<string, Group> groups;

        public GroupService()
        {
            this.groups = new Dictionary<string, Group>();
        }

        public void AddGroup(Group group)
        {
            groups.Add(group.GroupId, group);
        }

        public Group GetGroup(string groupId)
        {
            return groups[groupId];
        }

    }
}
