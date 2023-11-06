using FinanceCore.Domain.Entities;
using FinanceCore.Domain.Exceptions;
using FinanceCore.Repository.Dtos;
using FinanceCore.Repository.IRepository;
using FinanceCore.Repository.IRepository.IAccountRepository;
using FinanceCore.Repository.IRepository.IExpensesRepository;
using FinanceCore.Repository.IServices.IExpensesServices;


namespace FinanceApi.Services.ExpensesServices
{
    public class ExpensesWriteService : GenericWriteService<Expenses>, IExpensesWriteService
    {
        private readonly IExpensesWriteRepository _expensesWriteRepository;
        private readonly ICommit _commit;
        private readonly IAccountReadRepository _accountReadRepository;
        public ExpensesWriteService(IWriteRepository<Expenses> genericWriteRepository,IExpensesWriteRepository expensesWriteRepository,IAccountReadRepository accountReadRepository,ICommit commit) : base(genericWriteRepository)
        {
            _expensesWriteRepository = expensesWriteRepository;
            _accountReadRepository = accountReadRepository;
            _commit = commit;
        }

        public async Task<ResponseDto<ExpensesResponseDto>> AddExpenses(Expenses exp) 
        {//burada account yoksa hata verir onu düzelt
            var returnData= await _expensesWriteRepository.AddExpenses(exp);
            if (returnData is null)
            {
                return ResponseDto<ExpensesResponseDto>.Fail("bu account yok",200);
            }
           decimal _expensesMoney= returnData.Sum(y => y.ExpensesMoney);
           decimal AccountMaksMoney = returnData.Select(y => y.Account.Money).First();
          if (_expensesMoney + exp.ExpensesMoney >AccountMaksMoney)
          {
              //burada işlem yapılmayacak çünkü parası yok
              return ResponseDto<ExpensesResponseDto>.Fail("Kullanıcının yeterli parası yok", 200);
          }
          
         await _expensesWriteRepository.AddAsync(exp);
         return ResponseDto<ExpensesResponseDto>.Success(new ExpensesResponseDto()
         {
             ExpensesMoney = _expensesMoney,
             ExpensesMaksMoney = AccountMaksMoney
         },200);



        }
    }
}

