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
        
        
        public Task<T> GetCaching( string key)
        {

            return Task.FromResult( _redisClient.Get<T>(key));
        }

        public Task<bool> SetCaching( string key, T value,TimeSpan timeSpan)
        {
          return  Task.FromResult(_redisClient.Set<T>(key, value, timeSpan));
        }
    }
}
