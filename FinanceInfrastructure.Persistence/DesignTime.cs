using FinanceInfrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FinanceInfrastructure.Persistence
{
    public class DesignTime : IDesignTimeDbContextFactory<FinanceDbContext>
    {
        public FinanceDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<FinanceDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(DbConnectionString.GetConnectionString);
            return new FinanceDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
