using FinanceCore.Domain.Entities;
using FinanceCore.Repository.Dtos;
using FinanceCore.Repository.IRepository.IHashRepository;
using FinanceCore.Repository.IServices.IUserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FinanceApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserWriteService _userWriteService;
        private readonly IHash _hash;
        public UserController(IUserWriteService userWriteService,IHash hash)
        {
             _hash =hash;
            _userWriteService =userWriteService;
        }
        [HttpPost]
        public async Task<IActionResult> UserAdd([FromBody]UserDto userDto)
        {

            var EncodePassword = _hash.EncodePasswordToBase64(userDto.Password);
            userDto.Password = EncodePassword;
            var returnUser= await _userWriteService.AddUserAsync(userDto);

            var ResponseDto= ResponseDto<UserDto>.Success(returnUser, 200);

           return ResponseDto<UserDto>.ResponseData.Response(ResponseDto);
        }
        [HttpPost]
        public async Task<IActionResult> UserDelete([FromBody]UserDeleteDto userDeleteDto)
        {
            User user=await  _userWriteService.RemoveUserDeleteAsync(userDeleteDto);

            var ResponseDto = ResponseDto<User>.Success(user, 200);

           return ResponseDto<User>.ResponseData.Response<User>(ResponseDto);
        }
        [HttpPost]
        public async Task<IActionResult> UserUpdate([FromBody]User user)
        {
            var encodePassword = _hash.EncodePasswordToBase64(user.Password);
            user.Password = encodePassword;
            var users= await _userWriteService.UpdateAsync(user);
            var ResponseDto=ResponseDto<User>.Success(users, 200);
            return ResponseDto<User>.ResponseData.Response<User>(ResponseDto);
        }
    }
}
