using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Services.CacheExpired
{
    public static class Expiried
    {
        public static TimeSpan TokenCache => TimeSpan.FromMinutes(1);
    }
}
