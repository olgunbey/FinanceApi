using FinanceCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCore.Repository.IRepository.ICardRepository
{
    public interface ICardReadRepository:IReadRepository<Card>
    {
        Task<bool> HasCardTypeValue(int _cardtypeID);
        Task<CardType> IncludeCardTypesBankCard(int cardtypeID);
    }
}
