using FinanceCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Persistence.DatabaseContext
{
    public class FinanceDbContext:DbContext
    {
        public FinanceDbContext(DbContextOptions dbContextOptionsBuilder):base(dbContextOptionsBuilder)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts{ get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<AccountMoneyTransferLog> AccountMoneyTransferLog { get; set; }
       
    }
}
