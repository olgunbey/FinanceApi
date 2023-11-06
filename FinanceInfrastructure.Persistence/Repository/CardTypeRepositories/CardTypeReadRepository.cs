using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository.ICardTypeRepository;
using FinanceInfrastructure.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Persistence.Repository.CardTypeRepositories
{
    public class CardTypeReadRepository : GenericReadRepository<CardType>, ICardTypeReadRepository
    {
        public CardTypeReadRepository(FinanceDbContext financeDbContext) : base(financeDbContext)
        {
        }
    }
}
