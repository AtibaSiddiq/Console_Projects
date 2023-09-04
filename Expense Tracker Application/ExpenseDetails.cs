namespace Expense_Tracker_Application
{
    public class ExpenseDetails
    {
        public string expenseAmount { get; set; }
        public string categories { get; set; }
        public ExpenseDetails(string category, string expense)
        {
            this.categories = category;
            this.expenseAmount = expense;
        }
        public static ExpenseDetails Parse(string line)
        {
            string[] parse = line.Split('\t');
            return new ExpenseDetails(parse[0] , parse[1]);
        }
        public override string ToString()
        {
            return $"{categories}\t\t\t{expenseAmount}";
        }
    }
}