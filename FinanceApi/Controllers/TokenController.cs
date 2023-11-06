using FinanceCore.Repository.Dtos;
using FinanceCore.Repository.IServices;
using FinanceCore.Repository.IServices.IUserServices;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserReadService _userReadService;
        public TokenController(ITokenService tokenService,IUserReadService userReadService)
        {
            _tokenService = tokenService;
            _userReadService = userReadService;
        }
        [HttpPost]
        public  async Task<IActionResult> GenerateUserToken([FromBody]GenerateUserTokenUserDto userDto)
        {
            var _Response=await _userReadService.HasUserEmail(userDto.Email, userDto.Password);
            var requestUserTokenDto = new RequestUserTokenDto()
            {
                refreshToken = null,
                UserEmail = userDto.Email
            };
           var ResponseDto= await _tokenService.GeneratedUserTokenAsync(requestUserTokenDto);
           return ResponseDto<ResponseUserTokenDto>.ResponseData.Response(ResponseDto);
        }
        [HttpPost]
        public async Task<IActionResult> GenerateUserTokenUsingRefreshToken(string refreshtoken)
        {
            var ResponseDto= await _tokenService.GeneratedUserTokenUsingRefreshToken(refreshtoken);
            return ResponseDto<ResponseUserTokenDto>.ResponseData.Response(ResponseDto);
        }

        [HttpPost]
        public async Task<IActionResult> ToDepositMoney([FromBody]ToDepositMoneyRequestDto toDepositMoneyRequestDto)
        {
            
            return Ok();
        }
    }
}
