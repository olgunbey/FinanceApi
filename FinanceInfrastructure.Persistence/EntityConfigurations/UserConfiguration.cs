using FinanceCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).HasColumnType("nvarchar(15)");
            builder.Property(x => x.Surname).HasColumnType("nvarchar(8)");
            builder.Property(x => x.Password).HasColumnType("char(6)");
            builder.Property(x => x.CardID).IsRequired(false);

        }
    }
}
