using FinanceCore.Domain.Entities;
using FinanceCore.Repository.Dtos;
using FinanceCore.Repository.IRepository;
using FinanceCore.Repository.IServices.IExpensesServices;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesWriteService _expensesWriteService;
        private readonly IExpensesReadService _expensesReadService;

        public ExpensesController(IExpensesWriteService expensesWriteService, IExpensesReadService expensesReadService)
        {
            _expensesWriteService = expensesWriteService;
            _expensesReadService = expensesReadService;

        }
        [HttpPost]
        public async Task<IActionResult> ExpensesAccountAdd([FromBody]ExpensesAccountDto expensesAccountDto)
        {
            var _Expenses = new Expenses()
            {
                ExpensesDateTime = expensesAccountDto.ExpensesDateTime,
                ExpensesMoney = expensesAccountDto.ExpensesMoney,
                ExpensesDescription = expensesAccountDto.ExpensesDescription,
                AccountID = expensesAccountDto.AccountId,
            };
            var exp = await _expensesWriteService.AddExpenses(_Expenses);
            return ResponseDto<ExpensesResponseDto>.ResponseData.Response(exp);
        }
        [HttpGet]
        public async Task<IActionResult> UserExpenses([FromHeader] int id)
        {
            Expenses expenses = await _expensesReadService.GetByID(id);
            return ResponseDto<Expenses>.ResponseData.Response(ResponseDto<Expenses>.Success(expenses, 200));
        }
    }

}
