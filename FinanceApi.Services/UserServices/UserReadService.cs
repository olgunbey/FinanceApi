using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository;
using FinanceCore.Repository.IRepository.IUserRepository;
using FinanceCore.Repository.IServices.IUserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceCore.Domain.Exceptions;
using FinanceCore.Repository.Dtos;
using FinanceCore.Repository.IRepository.IHashRepository;

namespace FinanceApi.Services.UserServices
{
    public class UserReadService : GenericReadService<User>, IUserReadService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IHash _hash;

        public UserReadService(IReadRepository<User> repository, IUserReadRepository userReadRepository,IHash hash) : base(repository)
        {
            _userReadRepository = userReadRepository;
            _hash = hash;
        }


        public async Task<ResponseDto<User>> HasUserEmail(string email, string password)
        { 
            string EncodedPassword= _hash.EncodePasswordToBase64(password);

            User hasUser= await _userReadRepository.HasUserEmail(x => x.Email == email && x.Password == EncodedPassword);

            if (hasUser == null)
            {
                throw new NoUserException("geçersiz email veya şifre");
            }

            return ResponseDto<User>.Success(hasUser,200);

        }
    }
}
