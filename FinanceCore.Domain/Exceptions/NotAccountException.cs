using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Domain.Exceptions
{
    public class NotAccountException:Exception
    {
        public NotAccountException(string _msj) : base(_msj) { }
    }
}
