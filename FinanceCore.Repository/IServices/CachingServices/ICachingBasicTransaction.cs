using FinanceCore.Domain.Command;
using FinanceCore.Repository.IServices.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IServices.CachingServices
{
    public interface ICachingBasicTransaction<T> where T : class, new()
     {
        Task<bool> SetCaching(CacheEnum cacheEnum,string key, T value,TimeSpan timeSpan);
        Task<T> GetCaching(CacheEnum cacheEnum,string key);
    }
}
