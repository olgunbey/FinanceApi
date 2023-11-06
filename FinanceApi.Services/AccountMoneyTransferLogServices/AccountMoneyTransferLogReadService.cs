using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository;
using FinanceCore.Repository.IServices;
using FinanceCore.Repository.IServices.IAccountMoneyTransferLogServices;

namespace FinanceApi.Services.AccountMoneyTransferLogServices;

public class AccountMoneyTransferLogReadService:GenericReadService<AccountMoneyTransferLog>,IAccountMoneyTransferLogReadService
{
    public AccountMoneyTransferLogReadService(IReadRepository<AccountMoneyTransferLog> repository) : base(repository)
    {
    }
}