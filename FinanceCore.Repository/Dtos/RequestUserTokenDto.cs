using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.Dtos
{
    public class RequestUserTokenDto
    {
        public string UserEmail { get; set; }
        public string refreshToken { get; set; } = null;

    }
}
