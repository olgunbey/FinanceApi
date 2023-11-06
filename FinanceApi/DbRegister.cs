using FinanceInfrastructure.Persistence.DatabaseContext;
using FinanceInfrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using SaveChangesInterceptor = FinanceInfrastructure.Persistence.Interceptors.SaveChangesInterceptor;

namespace FinanceApi
{
    public static class DbRegister
    {
        public static void AddDbRegister(this IServiceCollection services,string dbaddress)
        {
            services.AddDbContext<FinanceDbContext>(opt =>
            {
                opt.UseSqlServer(dbaddress);
                opt.AddInterceptors(new SaveChangesInterceptor());
            });
        }
    }
}
