using System;
using System.Collections.Generic;
using System.Text;

namespace Splitwise.Models
{
    public abstract class Expense
    {
        private string Id;
        private string paidBy;
        private double amount;
        private ExpenseType type;
        private List<Split> splits;
        private ExpenseMetadata expenseMetadata;
        private string groupId;
        public Expense(string paidBy, double amount, ExpenseType type, List<Split> splits, ExpenseMetadata expenseMetadata, string groupId="")
        {
            this.Id = "";
            this.PaidBy = paidBy;
            this.Amount = amount;
            this.Type = type;
            this.splits = splits;
            this.ExpenseMetadata = expenseMetadata;
            this.groupId = groupId;
        }

        public string PaidBy { get => paidBy; set => paidBy = value; }
        public double Amount { get => amount; set => amount = value; }
        public ExpenseType Type { get => type; set => type = value; }
        public List<Split> Splits { get => splits; set => splits = value; }
        public ExpenseMetadata ExpenseMetadata { get => expenseMetadata; set => expenseMetadata = value; }

        public abstract bool Validate();
    } 
}
