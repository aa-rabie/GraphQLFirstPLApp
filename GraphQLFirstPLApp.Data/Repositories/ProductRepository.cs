using System;
using GraphQLFirstPLApp.Data;
using System.Threading.Tasks;
using GraphQLFirstPLApp.Data.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLFirstPLApp.Data.Repositories
{
    public class ProductRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public ProductRepository(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task<List<Product>> GetAll()
        {
            using var scope = _scopeFactory.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<CarvedRockDbContext>();
            return await dbContext.Products.ToListAsync();
        }
    }
}