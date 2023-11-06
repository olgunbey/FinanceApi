using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.Dtos
{
    public class ExpensesResponseDto
    {
        public decimal ExpensesMoney { get; set; }
        public decimal ExpensesMaksMoney { get; set; } //Limit
    }
}
