namespace FinanceCore.Repository.Dtos
{
    public class ExpensesAccountDto
    {
        public string ExpensesDescription { get; set; }
        public decimal ExpensesMoney { get; set; }
        public DateTime ExpensesDateTime { get; set; }
        public int AccountId { get; set; }
    }
}
