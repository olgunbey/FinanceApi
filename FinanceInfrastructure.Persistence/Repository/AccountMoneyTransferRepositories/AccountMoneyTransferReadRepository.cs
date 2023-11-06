using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository.IAccountMoneyTransferLog;
using FinanceInfrastructure.Persistence.DatabaseContext;

namespace FinanceInfrastructure.Persistence.Repository.AccountMoneyTransferRepositories;

public class AccountMoneyTransferReadRepository:GenericReadRepository<AccountMoneyTransferLog>,IAccountMoneyTransferLogReadRepository
{
    public AccountMoneyTransferReadRepository(FinanceDbContext financeDbContext) : base(financeDbContext)
    {
    }
}