
namespace Splitwise.Models
{
    using System.Collections.Generic;
    public abstract class Split
    {
        private User user;
        double amount;

        public Split(User user, double amount=0)
        {
            this.user = user;
            this.amount = amount;
        }

        public double Amount { get => amount; set => amount = value; }
        public User GetUser { get => user; set => user = value; }
    }
}