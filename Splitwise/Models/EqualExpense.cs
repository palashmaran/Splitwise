using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.Models
{
    public class EqualExpense : Expense
    {
        public EqualExpense(string paidBy, double amount, ExpenseType type, List<Split> splits, ExpenseMetadata expenseMetadata, string groupId = "") : base(paidBy, amount, type, splits, expenseMetadata, groupId = "")
        {

        }
        public override bool Validate()
        {
            foreach (var split in this.Splits)
            {
                var splitType = split.GetType();
                var equalSplitType = typeof(EqualSplit);
                if (!splitType.IsInstanceOfType(equalSplitType))
                    return false;
            }

            int noOfUsers = this.Splits.Count;
            double perUserShare = this.Amount/noOfUsers;
            foreach(var split in this.Splits)
            {
                if (perUserShare != split.Amount)
                    return false;
            }

            return true;
        }
    }
}
