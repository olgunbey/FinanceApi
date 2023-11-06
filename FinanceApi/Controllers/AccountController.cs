using FinanceCore.Domain.Entities;
using FinanceCore.Repository.Dtos;
using FinanceCore.Repository.IRepository.IAccountRepository;
using FinanceCore.Repository.IRepository.IHashRepository;
using FinanceCore.Repository.IServices.IAccountServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApi.Controllers
{
    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountWriteService _accountWriteService;
        private readonly IAccountReadService _accountReadService;
        public AccountController(IAccountWriteService accountWriteService, IAccountReadService accountReadService)
        {
            _accountWriteService = accountWriteService;
            _accountReadService = accountReadService;

        }
        [HttpPost]
        public async Task<IActionResult> AccountAdd([FromBody]AccountDto accountDto)
        {
          return  ResponseDto<AccountDto>.ResponseData.Response(await _accountWriteService.AddAcountAsnyc(accountDto));

        }
        [HttpDelete]
        public async Task<IActionResult> AccountDelete([FromBody]AccountDto accountDto)
        {
            var Account = new Account()
            {
                AccountNo = accountDto.AccountNo,
                IBAN = accountDto.IBAN,
                Money = accountDto.Money,
                UserID = accountDto.UserID,
                ID = accountDto.ID,
            };

            var ResponseDto= ResponseDto<Account>.Success(await _accountWriteService.RemoveAsync(Account), 200);

            return ResponseDto<Account>.ResponseData.Response(ResponseDto);
        }
        [HttpGet]
        public async Task<IActionResult> AccountExtre([FromHeader]int id)
        {
            return ResponseDto<List<UserDto>>.ResponseData.Response(await _accountReadService.GetExtre(id));
        }

    }
}
