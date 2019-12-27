using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLFirstPLApp.Data.Initialization
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public void Init()
        {
            using var scope = _scopeFactory.CreateScope();
            using (var dbContext = scope.ServiceProvider.GetRequiredService<CarvedRockDbContext>())
            {
                dbContext.Database.Migrate();
            }   
        }
    }
}
