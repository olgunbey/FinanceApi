using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Domain.Exceptions
{
    public class EncodException:Exception
    {
        public EncodException(string msj) : base(msj) { }
    }
}
