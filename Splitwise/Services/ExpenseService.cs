
namespace Splitwise.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Splitwise.contracts;
    using Splitwise.Models;
    using Splitwise.Services;

    public class ExpenseService : IExpense
    {
        private static List<Expense> expenses = new List<Expense>();
        private static Dictionary<string, Dictionary<string, double>> balanceSheet = new Dictionary<string, Dictionary<string, double>>();

        public ExpenseService()
        {

        }

        public void AddUserInBalanceSheet(string userId)
        {
            balanceSheet.Add(userId, new Dictionary<string, double>());
        }

        public Dictionary<string, double> GetOrCreateBalanceSheet(string userId)
        {
            if (!balanceSheet.ContainsKey(userId))
            {
                AddUserInBalanceSheet(userId);
            }

            return balanceSheet[userId];
        }

        public void AddExpense(string paidBy, double amount, ExpenseType type, List<Split> splits, ExpenseMetadata expenseMetadata, string groupId = "")
        {
            Expense expense = ExpenseFactory.CreateExpense(paidBy, amount, type, splits, expenseMetadata, groupId);
            expenses.Add(expense);

            var paidByUserBalanceSheet = this.GetOrCreateBalanceSheet(paidBy);

            foreach (var split in splits)
            {
                string paidTo = split.GetUser.UserId;

                if (paidTo.Equals(paidBy))
                {
                    continue;
                }

                if (paidByUserBalanceSheet.ContainsKey(paidTo))
                {
                    paidByUserBalanceSheet[paidTo] += split.Amount;
                }
                else
                {
                    paidByUserBalanceSheet.Add(paidTo, split.Amount);
                }

                var paidToUserBalanceSheet = this.GetOrCreateBalanceSheet(paidTo);

                if (paidToUserBalanceSheet.ContainsKey(paidBy))
                {
                    paidToUserBalanceSheet[paidBy] -= split.Amount;
                }
                else
                {
                    paidToUserBalanceSheet.Add(paidBy, -split.Amount);
                }
            }
        }
        public void Show()
        {
            var userList = UserService.UserList;

            foreach (var user in userList)
            {
                string userId = user.Key;
                var userBalanceSheet = GetOrCreateBalanceSheet(userId);

                foreach (var expense in userBalanceSheet)
                {
                    string username1 = userList[userId].Name;
                    string username2 = userList[expense.Key].Name;
                    double amount = expense.Value;
                    if (amount > 0)
                        printBalance(username1, username2, amount);
                }
            }
        }

        public void Show(string userId)
        {
            var userBalanceSheet = GetOrCreateBalanceSheet(userId);
            var userList = UserService.UserList;

            if (userBalanceSheet.Count == 0)
            {
                Console.WriteLine("No Balance");
            }
            else
            {
                foreach (var expense in userBalanceSheet)
                {
                    string username1 = userList[userId].Name;
                    string username2 = userList[expense.Key].Name;
                    double amount = expense.Value;
                    printBalance(username1, username2, amount);
                }
            }
        }
        private void printBalance(string username1, string username2, double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine(username1 + " " + "Owes" + " " + username2 + " : " + Math.Abs(amount));
            }
            else
            {
                Console.WriteLine(username2 + " " + "Owes" + " " + username1 + " : " + Math.Abs(amount));
            }
        }
    }
}

