
using FinanceApi.Cache.TokenCache;
using FinanceApi.Cache.UserCacheServices;
using FinanceApi.Services;
using FinanceApi.Services.AccountMoneyTransferLogServices;
using FinanceApi.Services.AccountServices;
using FinanceApi.Services.CardServices;
using FinanceApi.Services.CardTypeServices;
using FinanceApi.Services.ExpensesServices;
using FinanceApi.Services.TokenServices;
using FinanceApi.Services.UserServices;
using FinanceCore.Repository.IRepository;
using FinanceCore.Repository.IRepository.IAccountMoneyTransferLog;
using FinanceCore.Repository.IRepository.IAccountRepository;
using FinanceCore.Repository.IRepository.ICardRepository;
using FinanceCore.Repository.IRepository.ICardTypeRepository;
using FinanceCore.Repository.IRepository.IExpensesRepository;
using FinanceCore.Repository.IRepository.IHashRepository;
using FinanceCore.Repository.IRepository.IUserRepository;
using FinanceCore.Repository.IRepository.IUserTokenRepository;
using FinanceCore.Repository.IServices;
using FinanceCore.Repository.IServices.CachingServices;
using FinanceCore.Repository.IServices.IAccountMoneyTransferLogServices;
using FinanceCore.Repository.IServices.IAccountServices;
using FinanceCore.Repository.IServices.ICardServices;
using FinanceCore.Repository.IServices.ICardTypeService;
using FinanceCore.Repository.IServices.IExpensesServices;
using FinanceCore.Repository.IServices.IUserServices;
using FinanceInfrastructure.Infrastructure.HashRepository;
using FinanceInfrastructure.Persistence.Repository;
using FinanceInfrastructure.Persistence.Repository.AccountMoneyTransferRepositories;
using FinanceInfrastructure.Persistence.Repository.AccountRepositories;
using FinanceInfrastructure.Persistence.Repository.CardRepositories;
using FinanceInfrastructure.Persistence.Repository.CardTypeRepositories;
using FinanceInfrastructure.Persistence.Repository.ExpensesRepositories;
using FinanceInfrastructure.Persistence.Repository.UserRepositories;
using FinanceInfrastructure.Persistence.Repository.UserTokenRepositories;

using ServiceStack.Redis;

namespace FinanceApi
{
    public static class IOCRegister
    {
        public static void IOC(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUserWriteRepository), typeof(UserWriteRepository));
            services.AddScoped(typeof(IUserReadRepository), typeof(UserReadRepository));

            services.AddScoped(typeof(IReadRepository<>), typeof(GenericReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(GenericWriteRepository<>));

            services.AddScoped(typeof(IReadService<>), typeof(GenericReadService<>));
            services.AddScoped(typeof(IWriteService<>), typeof(GenericWriteService<>));

            services.AddScoped(typeof(IUserWriteService), typeof(UserWriteService));
            services.AddScoped(typeof(IUserReadService), typeof(UserReadService));

            services.AddScoped(typeof(ICardReadRepository), typeof(CardReadRepository));
            services.AddScoped(typeof(ICardReadService), typeof(CardReadService));

            services.AddScoped(typeof(ICardWriteService), typeof(CardWriteService));
            services.AddScoped(typeof(ICardWriteRepository), typeof(CardWriteRepository));

            services.AddScoped(typeof(ICardTypeReadRepository), typeof(CardTypeReadRepository));
            services.AddScoped(typeof(ICardTypeReadService), typeof(CardTypeReadService));

            services.AddScoped(typeof(ICardTypeWriteRepository), typeof(CardTypeWriteRepository));
            services.AddScoped(typeof(ICardTypeWriteService), typeof(CardTypeWriteService));

            services.AddScoped(typeof(IAccountReadRepository), typeof(AccountReadRepository));
            services.AddScoped(typeof(IAccountReadService), typeof(AccountReadService));

            services.AddScoped(typeof(IAccountWriteRepository), typeof(AccountWriteRepository));
            services.AddScoped(typeof(IAccountWriteService), typeof(AccountWriteService));

            services.AddScoped(typeof(IExpensesReadRepository), typeof(ExpensesReadRepository));
            services.AddScoped(typeof(IExpensesReadService), typeof(ExpensesReadService));

            services.AddScoped(typeof(IExpensesWriteRepository), typeof(ExpensesWriteRepository));
            services.AddScoped(typeof(IExpensesWriteService), typeof(ExpensesWriteService));


            services.AddScoped(typeof(IUserTokenReadRepository), typeof(UserTokenReadRepository));
            services.AddScoped(typeof(IUserTokenWriteRepository), typeof(UserTokenWriteRepository));

            services.AddScoped(typeof(IAccountMoneyTransferLogWriteService),typeof(AccountMoneyTransferLogWriteService));
            
            services.AddScoped(typeof(IAccountMoneyTransferLogReadService),typeof(AccountMoneyTransferLogReadService));
            
            services.AddScoped(typeof(IAccountMoneyTransferLogReadRepository),typeof(AccountMoneyTransferReadRepository));
            
            services.AddScoped(typeof(IAccountMoneyTransferLogWriteRepository), typeof(AccountMoneyTransferWriteRepository));
            

            services.AddScoped(typeof(ICommit), typeof(CommitRepository));

            services.AddScoped<ITokenService, TokenService>();
                
            services.AddScoped(typeof(IHash), typeof(HashRepository));
            services.AddScoped(typeof(ICachingBasicTransaction<>), typeof(TokenCaching<>));

            services.AddScoped<IRedisClientsManager>(options => new RedisManagerPool("localhost:1453"));
            
            services.AddScoped(typeof(IUserCache),typeof(UserCache));
        }
    }
}
