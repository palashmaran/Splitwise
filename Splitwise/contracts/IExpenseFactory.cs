
namespace Splitwise.contracts
{
    using Splitwise.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IExpenseFactory
    {
        public abstract  Expense CreateExpense(string paidBy, double amount, ExpenseType type, List<Split> splits, ExpenseMetadata expenseMetadata, string groupId = "");
    }
}
