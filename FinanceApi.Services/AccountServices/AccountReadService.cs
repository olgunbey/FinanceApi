using FinanceCore.Domain.Entities;
using FinanceCore.Repository.Dtos;
using FinanceCore.Repository.IRepository;
using FinanceCore.Repository.IRepository.IAccountRepository;
using FinanceCore.Repository.IServices.IAccountServices;

namespace FinanceApi.Services.AccountServices
{
    public class AccountReadService : GenericReadService<Account>, IAccountReadService
    {
        private readonly IAccountReadRepository _accountReadRepository;
        public AccountReadService(IReadRepository<Account> repository,IAccountReadRepository accountReadRepository) : base(repository)
        {
            _accountReadRepository = accountReadRepository;
        }

        public async Task<ResponseDto<List<ExtreDto>>> GetExtre(int id) //bunu düzelt
        {
          var UserExpenses= (await _accountReadRepository.GetExtre(id)).GroupBy(y=>y.ExpensesDateTime.Month).Select(y=> new ExtreDto()
          {
              Email=y.First().Account.User.Email,
          }).ToList(); //istediğim kullancının harcamaları burada gelecek

            return ResponseDto<List<ExtreDto>>.Success(UserExpenses,200);
        }

        public async Task AccountTransferMoney(MoneyTransferDto moneyTransferDto)//burayı düzgün bir hale getir trigger yaz veritabanını duzelt
        {
         Account account=await _accountReadRepository.AccountDifExpensesMoney(x => x.IBAN == moneyTransferDto.SendIBAN);
         decimal expensesMoney = account.Expenses.Sum(y => y.ExpensesMoney);
        if (account.Money - expensesMoney > moneyTransferDto.SendMoney) //kullanıcının kalan parası
        {
         Account targetAccount= await _accountReadRepository.FirsOrDefaultAsync(y => y.IBAN == moneyTransferDto.TargetIBAN);
         
        }
         
            throw new NotImplementedException();
        }
    }
}
