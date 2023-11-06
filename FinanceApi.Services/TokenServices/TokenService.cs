using FinanceApi.Services.CacheExpired;
using FinanceCore.Domain.Entities;
using FinanceCore.Domain.Exceptions;
using FinanceCore.Repository.Dtos;
using FinanceCore.Repository.IRepository.IUserRepository;
using FinanceCore.Repository.IRepository.IUserTokenRepository;
using FinanceCore.Repository.IServices;
using FinanceCore.Repository.IServices.CachingServices;
using FinanceCore.Repository.IServices.Enums;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinanceApi.Services.TokenServices
{
    public class TokenService : ITokenService
    {

        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserTokenReadRepository _userTokenReadRepository;
        private readonly IUserTokenWriteRepository _userTokenWriteRepository;
        private readonly ICachingBasicTransaction<CacheRefreshTokenDto> _cachingBasicTransaction;
        public TokenService(IUserReadRepository userReadRepository, IUserTokenReadRepository userTokenReadRepository, IUserTokenWriteRepository userTokenWriteRepository,ICachingBasicTransaction<CacheRefreshTokenDto> cachingBasicTransaction)
        {
            _userReadRepository = userReadRepository;
            _userTokenReadRepository = userTokenReadRepository;
            _userTokenWriteRepository = userTokenWriteRepository;
            _cachingBasicTransaction = cachingBasicTransaction;

        }
        public async Task<ResponseDto<ResponseUserTokenDto>> GeneratedUserTokenAsync(RequestUserTokenDto requestUserTokenDto)
        {
         User user= await _userReadRepository.FirsOrDefaultAsync(x => x.Email == requestUserTokenDto.UserEmail);
            if (user == null)
            {
                throw new NoUserException("No token, not do user exception");
            }

          var TokenResponseDto= await _cachingBasicTransaction.GetCaching(CacheEnum.GetEnum, "userRefreshToken");


            var userTokens = (await _userReadRepository.UserEmailToken(user)).ToList();

            if (TokenResponseDto != null) //buradaki kod tekrarını engelle!
            {

                if (userTokens.Count > 0)
                {
                    if (userTokens.FirstOrDefault(y => y.RefreshTokenLifeDateTime < DateTime.Now) == null) //token var süresi geçmemiş
                    {
                        throw new TokenIsValidErrorException($"{nameof(user)},This user has valid tokens");
                    }
                }
            }
            

            if(userTokens.Count>0)
            {
                if (userTokens.FirstOrDefault(y => y.RefreshTokenLifeDateTime < DateTime.Now) == null) //token var süresi geçmemiş
                {
                    throw new TokenIsValidErrorException($"{nameof(user)},This user has valid tokens");
                }
            }

            
            string secretKey = "UserTokenUserTokenUserTokenUserTokenUserTokenUserToken";
            Claim claim = new Claim(ClaimTypes.NameIdentifier,user.ID.ToString());

            var expirationAccessToken = DateTime.Now.AddMinutes(5);

            var key =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials signingCredentials = new(key,SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new(
                issuer:"issuerUserToken",
                audience:"AudienceUserToken",
                claims:new List<Claim>() { claim},
                expires:expirationAccessToken,
                signingCredentials: signingCredentials
                );
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

           var ResponseUserTokenDto=  new ResponseUserTokenDto()
            {
                AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken),
                RefreshToken = GenerateRefreshToken(),
                AccessLifeDateTime = expirationAccessToken,
                RefreshTokenLifeDateTime = DateTime.Now.AddMinutes(25)
            };
            if(requestUserTokenDto.refreshToken!=null)
            {
                await _userTokenWriteRepository.RemoveAsync(user.UserTokens.ToList()[0]);
            }
           var UserToken= await _userTokenWriteRepository.AddAsync(new UserToken()
            {
               RefreshToken=ResponseUserTokenDto.RefreshToken,
               UserID=user.ID,
               RefreshTokenLifeDateTime=ResponseUserTokenDto.RefreshTokenLifeDateTime,
            });
            var CacheRefreshToken = new CacheRefreshTokenDto()
            {
                RefreshToken=ResponseUserTokenDto.RefreshToken,
                DateTime=ResponseUserTokenDto.RefreshTokenLifeDateTime
            };

            var successcachingtransaction = await _cachingBasicTransaction.SetCaching(CacheEnum.SetEnum, "userRefreshToken", CacheRefreshToken,Expiried.TokenCache);

            if (!successcachingtransaction)
            {
                throw new CachingException("cache user refresh token exception");
            }
            return ResponseDto<ResponseUserTokenDto>.Success(ResponseUserTokenDto, 200);
        }

        public async Task<ResponseDto<ResponseUserTokenDto>> GeneratedUserTokenUsingRefreshToken(string refreshToken)
        {
          User user= (await _userTokenReadRepository.FirstOrDefaultImplicitLoadingUserAsync(refreshToken)).Single();


            if(user == null)
            {
              throw new NoUserException("no user exception");
            }
            if(!user.UserTokens.Any())
            {
                throw new NoRefreshTokenException("no refreshtoken exception");
            }

            //if(user.UserTokens.First()==null)
            //{
            //    throw new NoRefreshTokenException("no refreshtoken exception");
                
            //}
            if(user.UserTokens.First()!.RefreshTokenLifeDateTime<DateTime.Now)
            {
                await _userTokenWriteRepository.RemoveAsync(user.UserTokens.First());
                throw new ExpiredTokenException("expired token exception!");
            }
           var ReturnResponseDto= await GeneratedUserTokenAsync(new RequestUserTokenDto() { UserEmail=user.Email,refreshToken=user.UserTokens.Select(x=>x.RefreshToken).Single()});

           var updateUserToken= user.UserTokens.First();

            updateUserToken.RefreshToken = ReturnResponseDto.Data.RefreshToken;
            updateUserToken.RefreshTokenLifeDateTime=ReturnResponseDto.Data.RefreshTokenLifeDateTime;


            await _userTokenWriteRepository.UpdateAsync(updateUserToken);

            var cachToken = new CacheRefreshTokenDto()
            {
                RefreshToken=updateUserToken.RefreshToken,
                DateTime=updateUserToken.RefreshTokenLifeDateTime
            };
          var successtokencaching= await _cachingBasicTransaction.SetCaching(CacheEnum.SetEnum, "userRefreshToken", cachToken,Expiried.TokenCache);
            if(!successtokencaching)
            {
                throw new CachingException("dont user refresh token caching");
            }
            return ReturnResponseDto;

        }
        private string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
