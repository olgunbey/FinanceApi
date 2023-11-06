using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository.IAccountMoneyTransferLog;
using FinanceInfrastructure.Persistence.DatabaseContext;

namespace FinanceInfrastructure.Persistence.Repository.AccountMoneyTransferRepositories;

public class AccountMoneyTransferWriteRepository:GenericWriteRepository<AccountMoneyTransferLog>,IAccountMoneyTransferLogWriteRepository
{
    public AccountMoneyTransferWriteRepository(FinanceDbContext _financeDbContext) : base(_financeDbContext)
    {
    }
}