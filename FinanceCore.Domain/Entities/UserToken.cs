using FinanceCore.Domain.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Domain.Entities
{
    public class UserToken:BaseEntityID
    {
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenLifeDateTime { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
    }
}
