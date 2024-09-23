using Data.Data;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ReceiptDetailRepository : Repository<ReceiptDetail>, IReceiptDetailRepository
    {
        public ReceiptDetailRepository(TradeMarketDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<ReceiptDetail>> GetAllWithDetailsAsync()
        {
            return GetAllAsync();
        }
    }
}
