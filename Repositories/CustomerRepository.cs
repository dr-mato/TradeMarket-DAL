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
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(TradeMarketDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Customer>> GetAllWithDetailsAsync()
        {
            var customers = _dbContext.Set<Customer>().Include(c => c.Receipts).ThenInclude(r => r.ReceiptDetails).ToList();
            
            return (Task<IEnumerable<Customer>>)customers.AsEnumerable();
        }

        public Task<Customer> GetByIdWithDetailsAsync(int id)
        {
            return (Task<Customer>)_dbContext.Set<Customer>().Where(c => c.Id == id).Include(r => r.Receipts).ThenInclude(k => k.ReceiptDetails);
        }
    }
}
