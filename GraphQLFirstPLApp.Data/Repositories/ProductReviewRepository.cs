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
        private readonly IServiceScopeFactory _scopeFactory;

        public ProductReviewRepository(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task<List<ProductReview>> GetByProductId(int productId)
        {
            using var scope = _scopeFactory.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<CarvedRockDbContext>();
            return await dbContext.ProductReviews.Where(r => r.ProductId == productId).ToListAsync();
        }
    }
}