using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository.ICardRepository;
using FinanceCore.Repository.IRepository.ICardTypeRepository;
using FinanceInfrastructure.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Persistence.Repository.CardTypeRepositories
{
    public class CardTypeWriteRepository : GenericWriteRepository<CardType>, ICardTypeWriteRepository
    {
        public CardTypeWriteRepository(FinanceDbContext _financeDbContext) : base(_financeDbContext)
        {
        }
    }
}
