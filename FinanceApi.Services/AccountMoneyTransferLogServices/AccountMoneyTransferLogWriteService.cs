using System.Reflection.Metadata.Ecma335;
using FinanceCore.Domain.Entities;
using FinanceCore.Domain.Exceptions;
using FinanceCore.Repository.Dtos;
using FinanceCore.Repository.IRepository;
using FinanceCore.Repository.IRepository.IAccountRepository;
using FinanceCore.Repository.IRepository.IExpensesRepository;
using FinanceCore.Repository.IServices.IAccountMoneyTransferLogServices;

namespace FinanceApi.Services.AccountMoneyTransferLogServices;

public class AccountMoneyTransferLogWriteService:GenericWriteService<AccountMoneyTransferLog>,IAccountMoneyTransferLogWriteService
{
    private readonly IAccountReadRepository _accountReadRepository;
    private readonly IExpensesReadRepository _expensesReadRepository;
    private readonly IExpensesWriteRepository _expensesWriteRepository;
    private readonly ICommit _commit;
    public AccountMoneyTransferLogWriteService(ICommit commit,IExpensesWriteRepository expensesWriteRepository,IExpensesReadRepository expensesReadRepository,IAccountReadRepository accountReadRepository,IWriteRepository<AccountMoneyTransferLog> genericWriteRepository) : base(
        genericWriteRepository)
    {
        _accountReadRepository = accountReadRepository;
        _expensesReadRepository = expensesReadRepository;
        _expensesWriteRepository = expensesWriteRepository;
        _commit = commit;
    }

    public async Task<ResponseDto<MoneyTransferDto>> AccountMoneyTransferLogAddAsync(MoneyTransferDto moneyTransferDto)
    {
       Account SendIban=await _accountReadRepository.FirsOrDefaultAsync(y => y.IBAN == moneyTransferDto.SendIBAN);
       Account TargetIban= await _accountReadRepository.FirsOrDefaultAsync(y => y.IBAN == moneyTransferDto.TargetIBAN);
       if (SendIban is null)
       {
           return ResponseDto<MoneyTransferDto>.Fail("not send iban!",200);
       }

       if (TargetIban is null)
       {
           return ResponseDto<MoneyTransferDto>.Fail("not target iban!",200);
       }


    
       var IQueryableExpenses=  await _expensesWriteRepository.AddExpenses(new Expenses() { AccountID = SendIban.ID });
       decimal SendUserExpensesMoney= IQueryableExpenses.Sum(y => y.ExpensesMoney);
       decimal SendUserAccountMoney= IQueryableExpenses.Select(y => y.Account).First().Money;

       if (moneyTransferDto.SendMoney + SendUserExpensesMoney <= SendUserAccountMoney)
       {
          await _genericWriteRepository.AddAsync(new AccountMoneyTransferLog()
              {
                  SendMoney = moneyTransferDto.SendMoney,
                  SendIBAN = moneyTransferDto.SendIBAN,
                  TargetIBAN = moneyTransferDto.TargetIBAN
              }
          );
          return ResponseDto<MoneyTransferDto>.Success(200);
          // burada kullancının parasını düşür
          //savechanges interceptor kullanabilirsin!!
       }
       else
       {
           throw new NoLimitException("hesapta yeterli para yok");
           //hesapta para yok. (response fail)
       }
    
       
    }
}