using FinanceCore.Domain.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Domain.Entities
{
    public class CardType:BaseEntityID
    {
        public string Name { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}
