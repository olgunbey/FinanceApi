using FinanceCore.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IServices
{
    public interface ITokenService
    {
        Task<ResponseDto<ResponseUserTokenDto>> GeneratedUserTokenAsync(RequestUserTokenDto requestUserTokenDto);
        Task<ResponseDto<ResponseUserTokenDto>> GeneratedUserTokenUsingRefreshToken(string refreshToken);
    }
}
