
namespace Splitwise
{
    using Splitwise.contracts;
    using Splitwise.Controllers;
    using Splitwise.Models;
    using Splitwise.Services;
    using System;
    using System.Collections.Generic;

    class Driver
    {
        static void Main(string[] args)
        {
            IUserManagerFactory userManagerFactory = new UserManagerFactory();
            IExpenseManagerFactory expenseFactory = new ExpenseManagerFactory();
            IUser userService = new UserService();
            IExpense expenseService = new ExpenseService();

            UserManager userManager = userManagerFactory.CreateUserManager(userService);
            ExpenseManager expenseManager = expenseFactory.CreateExpenseManager(userService, expenseService);

            userManager.AddUser(new User("u1", "User1", "gaurav@workat.tech", "9876543210"));
            userManager.AddUser(new User("u2", "User2", "sagar@workat.tech", "9876543210"));
            userManager.AddUser(new User("u3", "User3", "hi@workat.tech", "9876543210"));
            userManager.AddUser(new User("u4", "User4", "mock-interviews@workat.tech", "9876543210"));

            while(true)
            {
                string command = Console.ReadLine();

                string[] commandArgs = command.Split(" ");

                if(commandArgs[0] == "SHOW")
                {
                    if (commandArgs.Length == 1)
                        expenseManager.Show();
                    else
                        expenseManager.Show(commandArgs[1]);
                }
                else if(commandArgs[0] == "EXPENSE")
                {
                    string groupId = "";
                    string paidBy = commandArgs[1];
                    double amount = Double.Parse(commandArgs[2]);
                    int noOfUsers = Int32.Parse(commandArgs[3]);
                    string type = commandArgs[4+noOfUsers];
                    
                    ExpenseType expenseType = (ExpenseType)Enum.Parse(typeof(ExpenseType), type);

                    int offset = 4 + noOfUsers;
                    List <Split> splits = new List<Split>();
                    ExpenseMetadata expenseMetadata = null;
                    for(int i=0;i<noOfUsers;i++)
                    {
                        string userId = commandArgs[4 + i];
                        offset++;
                        User user = userManager.GetUser(userId);
                        if (expenseType == ExpenseType.EXACT)
                        {
                            expenseType = ExpenseType.EXACT;
                            double amt = Double.Parse(commandArgs[offset]);
                            splits.Add(new ExactSplit(user,amt));
                        }
                        else if (expenseType == ExpenseType.EQUAL)
                        {
                            expenseType = ExpenseType.EQUAL;
                            splits.Add(new EqualSplit(user));
                        }
                        else if (expenseType == ExpenseType.PERCENT)
                        {
                            expenseType = ExpenseType.PERCENT;
                            double percent = Double.Parse(commandArgs[offset]);
                            splits.Add(new PercentSplit(user, percent));
                        }
                    }

                    expenseManager.AddExpense(paidBy, amount, expenseType, splits, expenseMetadata, groupId);
                }
            }

        }
    }
}

/*
SHOW
SHOW u1
EXPENSE u1 1000 4 u1 u2 u3 u4 EQUAL
*/