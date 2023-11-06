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
    public class CardWriteService : GenericWriteService<Card>, ICardWriteService
    {
        public CardWriteService(IWriteRepository<Card> genericWriteRepository) : base(genericWriteRepository)
        {
        }
    }
}
