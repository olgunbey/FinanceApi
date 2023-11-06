using Azure.Core.Extensions;
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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.IBAN).HasColumnType("char(26)");
            builder.HasOne(x => x.User).WithMany(x => x.Accounts).HasForeignKey(x => x.UserID);
            builder.Property(x => x.Money).HasDefaultValue(0);
        }
    }
}
