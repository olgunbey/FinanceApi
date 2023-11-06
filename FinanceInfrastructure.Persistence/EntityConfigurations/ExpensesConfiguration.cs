using FinanceCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Persistence.EntityConfigurations
{
    public class ExpensesConfiguration : IEntityTypeConfiguration<Expenses>
    {
        public void Configure(EntityTypeBuilder<Expenses> builder)
        {
            builder.HasKey(x => x.ID);
            
            
            builder.HasOne(x => x.Account).WithMany(x => x.Expenses).HasForeignKey(x => x.AccountID);
        }
    }
}
