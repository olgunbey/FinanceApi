using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Cache
{
    public class GenericCaching
    {
        private readonly IRedisClientsManager _redisClientsManager;
        private readonly IRedisClient _redisClient;
        public GenericCaching(IRedisClientsManager redisClientsManager)
        {
            _redisClientsManager = redisClientsManager;
            _redisClient = _redisClientsManager.GetClient();
            
        }
    }
}
