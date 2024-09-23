﻿using Data.Data;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(TradeMarketDbContext dbContext) : base(dbContext)
        {
        }
    }
}
