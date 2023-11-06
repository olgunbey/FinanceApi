using FinanceCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceInfrastructure.Persistence.EntityConfigurations;

public class AccountMoneyTransferLogConfiguration:IEntityTypeConfiguration<AccountMoneyTransferLog>
{
    public void Configure(EntityTypeBuilder<AccountMoneyTransferLog> builder)
    {
        builder.HasKey(x => x.ID);
    }
}