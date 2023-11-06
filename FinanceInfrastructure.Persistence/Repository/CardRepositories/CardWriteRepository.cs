using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository.ICardRepository;
using FinanceInfrastructure.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfrastructure.Persistence.Repository.CardRepositories
{
    public class CardWriteRepository : GenericWriteRepository<Card>, ICardWriteRepository
    {
        public CardWriteRepository(FinanceDbContext _financeDbContext) : base(_financeDbContext)
        {
        }
    }
}
