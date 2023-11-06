using FinanceCore.Domain.Command;
using FinanceCore.Repository.IServices.CachingServices;
using FinanceCore.Repository.IServices.Enums;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Cache.TokenCache
{
    public class TokenCaching<T>: ICachingBasicTransaction<T> where T : class ,new()
    {
        private readonly IRedisClientsManager _redisClientsManager;
        private readonly IRedisClient _redisClient;
        public TokenCaching(IRedisClientsManager redisClientsManager)
        {
            _redisClientsManager = redisClientsManager;
            _redisClient=redisClientsManager.GetClient();
        }

        public Task<T> GetCaching(CacheEnum cacheEnum, string key)
        {
            T deger = cacheEnum switch
            {
                CacheEnum.GetEnum => _redisClient.Get<T>(key),
            };

            return Task.FromResult(deger);
        }

        public Task<bool> SetCaching(CacheEnum cacheEnum, string key, T value,TimeSpan timeSpan)
        {
            return Task.FromResult(cacheEnum switch
            {
                CacheEnum.SetEnum => _redisClient.Set<T>(key, value,timeSpan),
            });
        }
    }
}
