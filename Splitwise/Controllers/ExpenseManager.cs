
namespace Splitwise.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Splitwise.contracts;
    using Splitwise.Models;
    using Splitwise.Services;
   
    public class ExpenseManager
    {
        private IExpense expenseService;
        
        public ExpenseManager( IExpense expenseService)
        {
            this.expenseService = expenseService;
        }

        public void AddExpense(string paidBy, double amount, ExpenseType type, List<Split> splits, ExpenseMetadata expenseMetadata, string groupId = "")
        {
            this.expenseService.AddExpense(paidBy,amount, type, splits, expenseMetadata, groupId);
        }

        public void Show()
        {
            this.expenseService.Show();
        }

        public void Show(string userId)
        {
            this.expenseService.Show(userId);
        }
    }
}
