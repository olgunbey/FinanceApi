using FinanceCore.Repository.Dtos;
using FinanceCore.Repository.IServices.IAccountMoneyTransferLogServices;
using FinanceCore.Repository.IServices.IAccountServices;
using Microsoft.AspNetCore.Mvc;


namespace FinanceApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AccountMoneyTransferController : ControllerBase
{
    private readonly IAccountMoneyTransferLogWriteService _accountMoneyTransferLogWriteService;
    public AccountMoneyTransferController(IAccountMoneyTransferLogWriteService accountMoneyTransferLogWriteService)
    {

        _accountMoneyTransferLogWriteService = accountMoneyTransferLogWriteService;
    }
    [HttpPost]
    public async Task<IActionResult> MoneyTransfer([FromBody]MoneyTransferDto moneyTransferDto)
    {
        return ResponseDto<MoneyTransferDto>.ResponseData.Response(await _accountMoneyTransferLogWriteService.AccountMoneyTransferLogAddAsync(moneyTransferDto));
    }
}