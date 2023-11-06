using FinanceCore.Domain.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Domain.Entities
{
    public class Card:BaseEntityID
    {
        public string CardName { get; set; }
        public CardType CardType { get; set; }
        public int CardTypeID { get; set; }
        public User User { get; set; }
    }
}
