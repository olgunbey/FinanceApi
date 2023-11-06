using FinanceCore.Domain.Entities;
using FinanceCore.Repository.IRepository;
using FinanceCore.Repository.IServices.ICardTypeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApi.Services.CardTypeServices
{
    public class CardTypeReadService : GenericReadService<CardType>, ICardTypeReadService
    {
        public CardTypeReadService(IReadRepository<CardType> repository) : base(repository)
        {
        }
    }
}
