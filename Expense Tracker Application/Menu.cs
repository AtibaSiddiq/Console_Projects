using System;

namespace Expense_Tracker_Application
{
    public class Menu
    {
        static IExpenses expense = new Expenses();
        public static void MainMenu()
        {
        label1:
            System.Console.WriteLine("Kindly select the operation to perform");
            System.Console.WriteLine("1. \t Add Expenses\n" +
                                     "2. \t View Expenses\n" +
                                     "3. \t Calculate Total Expenses\n" +
                                     "4. \t Calculate Expense for a particular category\n" +
                                     "0. \t Exit");
            int option;
            var isSuccessful = int.TryParse(Console.ReadLine(), out option);
            if (isSuccessful)
            {
                switch (option)
                {
                    case 1:
                        expense.AddExpenses();
                        expense.RefreshFile();
                        break;
                    case 2:
                        expense.ViewExpenses();
                        break;
                    case 3:
                        expense.CalculateExpenses();
                        break;
                    case 4:
                        expense.CalculateExpensesForEachCategory();
                        break;
                    case 0:
                        System.Console.WriteLine("Thank you for using SBM's Expense Tracker");
                        break;
                    default:
                        System.Console.WriteLine("Wrong input. Please try again");
                        goto label1;
                }
            }
            else 
            {
                System.Console.WriteLine("Wrong input. Please try again");
                goto label1;
            }


        }

    }
}