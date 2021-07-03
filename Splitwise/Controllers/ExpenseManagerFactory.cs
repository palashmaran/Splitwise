

namespace Splitwise.Controllers
{
    using Splitwise.contracts;
    using Splitwise.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ExpenseManagerFactory : IExpenseManagerFactory
    {
        public ExpenseManager CreateExpenseManager(IUser userService, IExpense expenseService)
        {
            return new ExpenseManager(userService, expenseService);
        }
    }
}
