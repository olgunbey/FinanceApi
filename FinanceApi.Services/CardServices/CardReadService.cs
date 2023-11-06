using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository;
using FinanceCore.Repository.IServices.ICardServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Services.CardServices
{
    public class CardReadService : GenericReadService<Card>, ICardReadService
    {
        public CardReadService(IReadRepository<Card> repository) : base(repository)
        {
        }
    }
}
