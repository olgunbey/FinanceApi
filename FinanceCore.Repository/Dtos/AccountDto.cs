using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.Dtos
{
    public class AccountDto
    {
        public int ID { get; set; }
        public string IBAN { get; set; }
        public decimal Money { get; set; }
        public int AccountNo { get; set; }
        public int UserID { get; set; }
    }
}
