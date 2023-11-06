using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IRepository.IHashRepository
{
    public interface IHash
    {
        string EncodePasswordToBase64(string password);
        string DecodeFrom64(string encodedData);
    }
}
