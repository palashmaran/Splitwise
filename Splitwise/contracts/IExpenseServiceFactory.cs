
namespace Splitwise.contracts
{
    using Splitwise.Controllers;
    using Splitwise.Models;
    using Splitwise.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IExpenseServiceFactory
    { 
       public abstract IExpense CreateExpenseService(ServiceType eXPENSESERVICE);
    }
}
