using Data.Data;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(TradeMarketDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Product>> GetAllWithDetailsAsync()
        {
            var products = _dbContext.Set<Product>().Include(p => p.ReceiptDetails).ToList();
            
            return (Task<IEnumerable<Product>>)products.AsEnumerable();
        }

        public Task<Product> GetByIdWithDetailsAsync(int id)
        {
            return (Task<Product>)_dbContext.Set<Product>().Where(c => c.Id == id).Include(r => r.ReceiptDetails);
        }
    }
}
