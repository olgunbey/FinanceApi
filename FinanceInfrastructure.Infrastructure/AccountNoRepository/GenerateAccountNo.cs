using FinanceCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Infrastructure.AccountNoRepository
{
    public static class GenerateAccountNo
    {
        public static int AccountNoGenerate()
        {
            Random random = new Random();
            int AccountNo= random.Next(1000, 9999);

            return AccountNo;
        }
    }
}
