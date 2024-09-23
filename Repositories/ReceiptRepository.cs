using Data.Data;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ReceiptRepository : Repository<Receipt>, IReceiptRepository
    {
        public ReceiptRepository(TradeMarketDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Receipt>> GetAllWithDetailsAsync()
        {
            var receipts = _dbContext.Set<Receipt>()
                .Include(r => r.ReceiptDetails) 
                .ToList();                      

            return Task.FromResult(receipts.AsEnumerable());
        }

        public Task<Receipt> GetByIdWithDetailsAsync(int id)
        {
            return (Task<Receipt>)_dbContext.Set<Receipt>().Where(c => c.Id == id).Include(r => r.ReceiptDetails);
        }
    }
}
