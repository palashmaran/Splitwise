using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.Models
{
    public class ExactExpense : Expense
    {
        public ExactExpense(string paidBy, double amount, ExpenseType type, List<Split> splits, ExpenseMetadata expenseMetadata, string groupId = "") : base(paidBy, amount, type, splits, expenseMetadata, groupId = "")
        {

        }
        public override bool Validate()
        {
            foreach (var split in this.Splits)
            {
                var splitType = split.GetType();
                var exactSplitType = typeof(ExactSplit);
                if (!splitType.IsInstanceOfType(exactSplitType))
                    return false;
            }

            double totalAmount = 0;
            foreach (var split in this.Splits)
            {
                totalAmount += split.Amount;
            }

            if (this.Amount == totalAmount)
                return true;

            return false;
        }
    }
}
