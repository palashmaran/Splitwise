
namespace Splitwise.Services
{
    using Splitwise.contracts;
    using Splitwise.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExpenseFactory
    {
        public  static Expense CreateExpense(string paidBy, double amount, ExpenseType type, List<Split> splits, ExpenseMetadata expenseMetadata, string groupId="")
        {
            switch(type)
            {
                case ExpenseType.EXACT:
                    return new ExactExpense(paidBy, amount, type, splits, expenseMetadata, groupId);
                case ExpenseType.EQUAL:
                    int noOfUsers = splits.Count;
                    double splitAmount = amount / noOfUsers;
                    foreach(var split in splits)
                    {
                        split.Amount = splitAmount;
                    }
                    return new EqualExpense(paidBy, amount, type, splits, expenseMetadata, groupId);
                case ExpenseType.PERCENT:
                    foreach (PercentSplit split in splits)
                    {
                        splitAmount = amount * (split.Percent/100);
                        split.Amount = splitAmount;
                    }
                    return new PercentExpense(paidBy, amount, type, splits, expenseMetadata, groupId);
            }

            return null;
        }
    }
}
