using FinanceCore.Domain.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Domain.Entities
{
    public class Expenses:BaseEntityID
    {
        public string ExpensesDescription { get; set; }
        public decimal ExpensesMoney { get; set; }
        public DateTime ExpensesDateTime { get; set; }
        public Account Account { get; set; }
        public int AccountID{ get; set; }
    }
}
