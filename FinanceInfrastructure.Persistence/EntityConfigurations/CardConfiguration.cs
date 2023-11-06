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
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.CardName).HasColumnType("nvarchar(15)");
            builder.HasOne(x => x.User).WithOne(x => x.Card).HasForeignKey<User>(x => x.CardID);
            builder.HasOne(x => x.CardType).WithMany(x => x.Cards).HasForeignKey(x => x.CardTypeID);
        }
    }
}
