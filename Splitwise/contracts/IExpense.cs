
namespace Splitwise.contracts
{
    using Splitwise.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IExpense
    {
        public abstract void AddExpense(string paidBy, double amount, ExpenseType type, List<Split> splits, ExpenseMetadata expenseMetadata, string groupId = "");
        public abstract void Show();
        public abstract void Show(string userId);
    }
}
