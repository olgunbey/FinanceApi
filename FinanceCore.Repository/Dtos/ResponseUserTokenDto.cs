using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.Dtos
{
    public class ResponseUserTokenDto
    {
        public string AccessToken { get; set; }
        public DateTime AccessLifeDateTime { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenLifeDateTime { get; set; }
    }
}
