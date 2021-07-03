using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.Models
{
    class PercentExpense : Expense
    {
        public PercentExpense(string paidBy, double amount, ExpenseType type, List<Split> splits, ExpenseMetadata expenseMetadata, string groupId = "") : base(paidBy, amount, type, splits, expenseMetadata, groupId = "")
        {

        }
        public override bool Validate()
        {
            foreach (var split in this.Splits)
            {
                var splitType = split.GetType();
                var percentSplitType = typeof(PercentSplit);
                if (!splitType.IsInstanceOfType(percentSplitType))
                    return false;
            }
            
            double totalPercent = 100;
            double sumPercent = 0;

            foreach (var split in this.Splits)
            {
                PercentSplit percentsplit = (PercentSplit) split;
                sumPercent += percentsplit.Percent;
            }

            if (totalPercent == sumPercent)
                return true;

            return false;
        }
    }
}
