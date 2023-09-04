namespace Expense_Tracker_Application
{
    public interface IExpenses
    {
        void AddExpenses();
        void ViewExpenses();
        void CalculateExpenses();
        void CalculateExpensesForEachCategory();
        void RefreshFile();
    }
}