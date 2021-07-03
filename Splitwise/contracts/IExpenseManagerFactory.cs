
namespace Splitwise.contracts
{
    using Splitwise.Controllers;
    using Splitwise.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IExpenseManagerFactory
    {
        public abstract ExpenseManager CreateExpenseManager(IUser userService, IExpense expenseService);
    }
}
