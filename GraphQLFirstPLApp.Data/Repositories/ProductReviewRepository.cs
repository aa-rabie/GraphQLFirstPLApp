using System;
using GraphQLFirstPLApp.Data;
using System.Threading.Tasks;
using GraphQLFirstPLApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLFirstPLApp.Data.Repositories
{
    public class ProductReviewRepository
    {
        private readonly CarvedRockDbContext _dbContext;

        public ProductReviewRepository(CarvedRockDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<ProductReview>> GetByProductId(int productId)
        {
            return _dbContext.ProductReviews.Where(r => r.ProductId == productId).ToListAsync();
        }
    }
}