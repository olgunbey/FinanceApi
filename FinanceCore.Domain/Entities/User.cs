using FinanceCore.Domain.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Domain.Entities
{
    public class User:BaseEntityID
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public Card Card { get; set; }
        public int? CardID { get; set; }
        public int BankKardID  { get; set; }
        public ICollection<UserToken> UserTokens { get; set; }
    }
}
