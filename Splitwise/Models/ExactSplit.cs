using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.Models
{
    public class ExactSplit : Split
    {
        public ExactSplit(User user, double amount) : base(user,amount)
        {
        }

    }
}
