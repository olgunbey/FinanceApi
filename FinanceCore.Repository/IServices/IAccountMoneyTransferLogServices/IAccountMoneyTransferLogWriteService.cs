using FinanceCore.Domain.Entities;
using FinanceCore.Repository.Dtos;

namespace FinanceCore.Repository.IServices.IAccountMoneyTransferLogServices;

public interface IAccountMoneyTransferLogWriteService:IWriteService<AccountMoneyTransferLog>
{
    Task<ResponseDto<MoneyTransferDto>> AccountMoneyTransferLogAddAsync(MoneyTransferDto moneyTransferDto);
}