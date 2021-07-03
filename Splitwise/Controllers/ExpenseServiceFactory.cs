

namespace Splitwise.Controllers
{
    using Splitwise.contracts;
    using Splitwise.Models;
    using Splitwise.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ExpenseServiceFactory : IExpenseServiceFactory
    {
       
        public IExpense CreateExpenseService(ServiceType type)
        {
            if(type == ServiceType.EXPENSESERVICE)
                return new ExpenseService();

            return null;
        }
    }
}
