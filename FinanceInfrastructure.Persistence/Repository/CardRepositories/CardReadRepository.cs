using FinanceCore.Domain.Entities;
using FinanceCore.Domain.Exceptions;
using FinanceCore.Repository.IRepository.ICardRepository;
using FinanceInfrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Persistence.Repository.CardRepositories
{
    public class CardReadRepository : GenericReadRepository<Card>, ICardReadRepository
    {

        public CardReadRepository(FinanceDbContext financeDbContext) : base(financeDbContext)
        {
        }

        public async Task<bool> HasCardTypeValue(int _cardtypeID)
        {
          return await _FinanceDbContext.Cards.AnyAsync(x => x.CardTypeID == _cardtypeID);
        }

        public async Task<CardType> IncludeCardTypesBankCard(int cardtypeID) //cards tablosunda sadece bankkartları getirir
        {
           var Cards= await _FinanceDbContext.Cards.FirstOrDefaultAsync(x => x.CardTypeID == cardtypeID);
            if(Cards == null)
            {
                throw new NoBankCardException("NobankCardException");
            }
           return await _FinanceDbContext.Cards.Entry(Cards).Reference(y => y.CardType).Query().FirstOrDefaultAsync(x => x.ID == (int)CardTypes.BankCard);
        }
    }
    public enum CardTypes
    {
        CreditCard=1,
        BankCard=2,
        BankCardChildren=3
    }
}
