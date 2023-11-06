using FinanceCore.Domain.Entities;
using FinanceCore.Domain.Exceptions;
using FinanceCore.Repository.Dtos;
using FinanceCore.Repository.IRepository;
using FinanceCore.Repository.IRepository.ICardRepository;
using FinanceCore.Repository.IRepository.IHashRepository;
using FinanceCore.Repository.IServices.IUserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Services.UserServices
{
    public class UserWriteService : GenericWriteService<User>, IUserWriteService 
    {
        private readonly IReadRepository<User> _userReadRepository;
        private readonly IWriteRepository<User> _userWriteRepository;
        private readonly IHash _hash;
        private readonly ICardReadRepository _cardReadRepository;
        
        public UserWriteService(IWriteRepository<User> genericWriteRepository, IReadRepository<User> readRepository,IHash hash, ICardReadRepository cardReadRepository) : base(genericWriteRepository)
        {
            _userReadRepository = readRepository;
            _userWriteRepository = genericWriteRepository;
            _hash = hash;
            _cardReadRepository = cardReadRepository;
        }

        public async Task<UserDto> AddUserAsync(UserDto userDto)
        {
            string EncodPassword = _hash.EncodePasswordToBase64(userDto.Password);
            if (userDto.BankKardID != 0) //bankkartıd 0 olamaz
            {
            CardType card=  await _cardReadRepository.IncludeCardTypesBankCard(userDto.BankKardID);
                if(card==null)
                {
                    throw new InvalidCardException("invalid card exception");
                }
            }
            else
            {
                throw new NoBankCardException("No bank card exception");
            }
            await _userWriteRepository.AddAsync(new User()
            {
                BirthDate = userDto.BirthDate,
                CardID = userDto.CardID =userDto.CardID==0?null:userDto.CardID,
                BankKardID = userDto.BankKardID,
                Email = userDto.Email,
                Name = userDto.Name,
                Password = EncodPassword,
                Surname = userDto.Surname,
            });
            return userDto; 
        }

        public async Task<User> RemoveUserDeleteAsync(UserDeleteDto userDeleteDto)
        {
            var hasUser=  await _userReadRepository.FirsOrDefaultAsync(x=>x.Email==userDeleteDto.Email);

            hasUser= hasUser != null ? hasUser : throw new EmptyEntity("User not found");

            return  await _genericWriteRepository.RemoveAsync(hasUser);
        } 
    }
}
