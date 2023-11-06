using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Domain.Exceptions
{
    public class CachingException:Exception
    {
        public CachingException(string _msj) : base(_msj) { }
    }
}
