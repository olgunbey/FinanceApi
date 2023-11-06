using FinanceCore.Domain.Entities;
using FinanceCore.Repository.Dtos;
using FinanceCore.Repository.IRepository;
using FinanceCore.Repository.IRepository.IAccountRepository;
using FinanceCore.Repository.IServices.IAccountServices;
using FinanceInfrastructure.Infrastructure.AccountNoRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Services.AccountServices
{
    public class AccountWriteService : GenericWriteService<Account>, IAccountWriteService
    {
        private readonly IAccountWriteRepository _accountWriteRepository;
        private readonly IAccountReadRepository _accountReadRepository;
        public AccountWriteService(IWriteRepository<Account> genericWriteRepository,IAccountWriteRepository accountWriteRepository,IAccountReadRepository accountReadRepository) : base(genericWriteRepository)
        {
            _accountWriteRepository = accountWriteRepository;
            _accountReadRepository = accountReadRepository;
        }

        public async Task<ResponseDto<AccountDto>> AddAcountAsnyc(AccountDto account)
        {
            var _account = new Account()
            {
                AccountNo = account.AccountNo,
                IBAN = account.IBAN,
                UserID = account.UserID,
                Money = account.Money,
            };

            while (true)
            {
                int _GenerateAccountNo = GenerateAccountNo.AccountNoGenerate();
                if ((await _accountReadRepository.FirsOrDefaultAsync(x=>x.AccountNo==_GenerateAccountNo)) is null)
                {
                    _account.AccountNo = _GenerateAccountNo;
                    break;
                }
                else
                {
                }                
            }
          var Accounts= await _accountWriteRepository.AddAsync(_account);

            var AccountDto = new AccountDto()
            {
                AccountNo = Accounts.AccountNo,
                IBAN = Accounts.IBAN,
                UserID = Accounts.UserID,
                Money = Accounts.Money,
            };
            return ResponseDto<AccountDto>.Success(AccountDto, 200);
            
        }
    }
}
