using System;
using System.Collections.Generic;
using System.IO;

namespace Expense_Tracker_Application
{
    public class Expenses : IExpenses
    {
        static List<ExpenseDetails> AllExpenses = new List<ExpenseDetails>();
        static List<ExpenseDetails> expenses = new List<ExpenseDetails>();
        
        public Expenses()
        {
            try
            {
                if (File.Exists("Expense Tracker.txt"))
                {
                    var texts = File.ReadAllLines("Expense Tracker.txt");
                    if (texts is not null)
                    {
                        foreach (var line in texts)
                        {
                            var text = ExpenseDetails.Parse(line);
                            AllExpenses.Add(text);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void AddExpenses()
        {
        label1:
            System.Console.WriteLine("Enter your expense amount");
            double expense;
            var isCorrect = double.TryParse(Console.ReadLine(), out expense);
            if (isCorrect)
            {
                if (expense < 0)
                {
                    System.Console.WriteLine("Wrong Input. Please try again");
                    goto label1;
                }
                else
                {
                var expense1 = expense.ToString();
                label2:
                    System.Console.WriteLine("Enter the expense categories out of the following categories:");
                    System.Console.WriteLine("1. \t Utilities(Electricity, Water, Gas)\n" +
                                             "2. \t Transportation(Fuel, Public Transportation)\n" +
                                             "3. \t Entertainment(Movies, Concert, Events)\n" +
                                             "4. \t Healthcare(Medical Expenses, Prescriptions)\n" +
                                             "5. \t Education(Books, Courses, Workshops");
                    int choice;
                    var isSuccessful = int.TryParse(Console.ReadLine(), out choice);
                    if (isSuccessful)
                    {
                        switch (choice)
                        {
                            case 1:
                                ExpenseDetails details = new ExpenseDetails("Utilities(Electricity, Water, Gas)", expense1);
                                AllExpenses.Add(details);
                                expenses.Add(details);
                                System.Console.WriteLine("Expenses added succesfully");
                            label3:
                                System.Console.WriteLine("Do you want to add another expense\n1. \t Yes\n2. \t No");
                                int option1;
                                var isCorrect1 = int.TryParse(Console.ReadLine(), out option1);
                                if (isCorrect)
                                {
                                    if (option1 == 2)
                                    {
                                        Menu.MainMenu();
                                    }
                                    else if (option1 == 1)
                                    {
                                        goto label1;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Wrong input. Please try again");
                                        goto label3;
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("Wrong input. Please try again");
                                    goto case 1;
                                }
                                break;
                            case 2:
                                ExpenseDetails details1 = new ExpenseDetails( "Transportation(Fuel, Public Transportation)",expense1);
                                AllExpenses.Add(details1);
                                expenses.Add(details1);
                                System.Console.WriteLine("Expenses added succesfully");
                                System.Console.WriteLine("Do you want to add another expense\n1. \t Yes\n2. \t No");
                                int option2;
                                var isCorrect2 = int.TryParse(Console.ReadLine(), out option2);
                                if (isCorrect2)
                                {
                                    if (option2 == 2)
                                    {
                                        Menu.MainMenu();
                                    }
                                    else if (option2 == 1)
                                    {
                                        goto label1;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Wrong input. Please try again");
                                        goto case 2;
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("Wrong input. Please try again");
                                    goto case 2;
                                }
                                break;
                            case 3:
                                ExpenseDetails details2 = new ExpenseDetails("Entertainment(Movies, Concert, Events)", expense1);
                                AllExpenses.Add(details2);
                                expenses.Add(details2);
                                System.Console.WriteLine("Expenses added succesfully");
                                System.Console.WriteLine("Do you want to add another expense\n1. \t Yes\n2. \t No");
                                int option3;
                                var isCorrect3 = int.TryParse(Console.ReadLine(), out option3);
                                if (isCorrect3)
                                {
                                    if (option3 == 2)
                                    {
                                        Menu.MainMenu();
                                    }
                                    else if (option3 == 1)
                                    {
                                        goto label1;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Wrong input. Please try again");
                                        goto case 3;
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("Wrong input. Please try again");
                                    goto case 3;
                                }
                                break;
                            case 4:
                                ExpenseDetails details3 = new ExpenseDetails("Healthcare(Medical Expenses, Prescriptions)", expense1);
                                AllExpenses.Add(details3);
                                expenses.Add(details3);
                                System.Console.WriteLine("Expenses added succesfully");
                                System.Console.WriteLine("Do you want to add another expense\n1. \t Yes\n2. \t No");
                                int option4;
                                var isCorrect4 = int.TryParse(Console.ReadLine(), out option4);
                                if (isCorrect4)
                                {
                                    if (option4 == 2)
                                    {
                                        Menu.MainMenu();
                                    }
                                    else if (option4 == 1)
                                    {
                                        goto label1;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Wrong input. Please try again");
                                        goto case 4;
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("Wrong input. Please try again");
                                    goto case 4;
                                }
                                break;
                            case 5:
                                ExpenseDetails details4 = new ExpenseDetails("Education(Books, Courses, Workshops)", expense1);
                                AllExpenses.Add(details4);
                                expenses.Add(details4);
                                System.Console.WriteLine("Expenses added succesfully");
                                System.Console.WriteLine("Do you want to add another expense\n1. \t Yes\n2. \t No");
                                int option5;
                                var isCorrect5 = int.TryParse(Console.ReadLine(), out option5);
                                if (isCorrect5)
                                {
                                    if (option5 == 2)
                                    {
                                        Menu.MainMenu();
                                    }
                                    else if (option5 == 1)
                                    {
                                        goto label1;
                                    }
                                    else
                                    {
                                        System.Console.WriteLine("Wrong input. Please try again");
                                        goto case 5;
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine("Wrong input. Please try again");
                                    goto case 5;
                                }
                                break;
                            default:
                                System.Console.WriteLine("Wrong input. Please try again");
                                goto label2;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong input. Please try again");
                        goto label2;
                    }
                }
            }
            else
            {
                System.Console.WriteLine("Wrong input. Please try again");
                goto label1;
            }
        }
        public void ViewExpenses()
        {
            if (expenses.Count == 0)
            {
            case1:
                System.Console.WriteLine("You have no expenses. Do you wish to add your expenses?\n1. Yes 2. No");
                int choice;
                var isSuccessful = int.TryParse(Console.ReadLine(), out choice);
                if (isSuccessful)
                {
                    if (choice == 2)
                    {
                        Menu.MainMenu();
                    }
                    else if (choice == 1)
                    {
                        AddExpenses();
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong input. Please try again");
                        goto case1;
                    }
                }
                else
                {
                    System.Console.WriteLine("Wrong input. Please try again");
                    goto case1;
                }
            }
            else
            {
                System.Console.WriteLine("Your expenses are: ");
                foreach (var item in expenses)
                {
                    System.Console.WriteLine(item.categories + "\t" + item.expenseAmount);
                }
                Menu.MainMenu();
            }
        }
        public void CalculateExpenses()
        {
            double sum = 0;
            foreach (var item in expenses)
            {
                sum += Convert.ToDouble(item.expenseAmount);
            }
            System.Console.WriteLine($"Total Expenses = {sum}");
            Menu.MainMenu();
        }
        public void CalculateExpensesForEachCategory()
        {
        label:
            System.Console.WriteLine("Enter the category to calculate:");
            System.Console.WriteLine("1. \t Utilities(Electricity, Water, Gas)\n" +
                                     "2. \t Transportation(Fuel, Public Transportation)\n" +
                                     "3. \t Entertainment(Movies, Concert, Events)\n" +
                                     "4. \t Healthcare(Medical Expenses, Prescriptions)\n" +
                                     "5. \t Education(Books, Courses, Workshops)\n");
            int choice;
            var isSuccessful2 = int.TryParse(Console.ReadLine(), out choice);
            double sum = 0;
            if (isSuccessful2)
            {
                switch (choice)
                {
                    case 1:
                        string category = "Utilities(Electricity, Water, Gas)";
                        foreach (var item in expenses)
                        {
                            if (item.categories == category)
                            {
                                sum += Convert.ToDouble(item.expenseAmount);
                                break;
                            }
                        }
                        System.Console.WriteLine($"Your total expenses for {category} category is {sum}");
                        Menu.MainMenu();
                        break;
                    case 2:
                        string category1 = "Transportation(Fuel, Public Transportation)";
                        foreach (var item in expenses)
                        {
                            if (item.categories == category1)
                            {
                                sum += Convert.ToDouble(item.expenseAmount);
                                break;
                            }
                        }
                        System.Console.WriteLine($"Your total expenses for {category1} category is {sum}");
                        Menu.MainMenu();
                        break;
                    case 3:
                        string category2 = "Entertainment(Movies, Concert, Events)";
                        foreach (var item in expenses)
                        {
                            if (item.categories == category2)
                            {
                                sum += Convert.ToDouble(item.expenseAmount);
                                break;
                            }
                        }
                        System.Console.WriteLine($"Your total expenses for {category2} category is {sum}");
                        Menu.MainMenu();
                        break;
                    case 4:
                        string category3 = "Healthcare(Medical Expenses, Prescriptions)";
                        foreach (var item in expenses)
                        {
                            if (item.categories == category3)
                            {
                                sum += Convert.ToDouble(item.expenseAmount);
                                break;
                            }
                        }
                        System.Console.WriteLine($"Your total expenses for {category3} category is {sum}");
                        Menu.MainMenu();
                        break;
                    case 5:
                        string category4 = "Education(Books, Courses, Workshops)";
                        foreach (var item in expenses)
                        {
                            if (item.categories == category4)
                            {
                                sum += Convert.ToDouble(item.expenseAmount);
                                break;
                            }
                        }
                        System.Console.WriteLine($"Your total expenses for {category4} category is {sum}");
                        Menu.MainMenu();
                        break;
                    default:
                        System.Console.WriteLine("Wrong input. Please try again");
                        goto label;
                }
            }
        }
        public void RefreshFile()
        {
            TextWriter write = new StreamWriter("Expense Tracker.txt", true);
            foreach (var expense in AllExpenses)
            {
                write.WriteLine(expense.ToString());
            }
            write.Flush();
            write.Close();
        }
    }
}