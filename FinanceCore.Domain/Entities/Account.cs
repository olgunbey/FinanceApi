using FinanceCore.Domain.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Domain.Entities
{
    public class Account:BaseEntityID
    {
        public string IBAN { get; set; }
        public decimal Money { get; set; }
        public int AccountNo { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public ICollection<Expenses> Expenses{ get; set; }

    }
}
