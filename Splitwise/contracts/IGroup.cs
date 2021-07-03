using Splitwise.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.Services
{
    public interface IGroup
    {
        public void AddGroup(Group group);
        public Group GetGroup(string groupId);
    }
}
