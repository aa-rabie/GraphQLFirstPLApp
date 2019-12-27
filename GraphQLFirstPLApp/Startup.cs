using System;
using GraphQLFirstPLApp.Data;
using GraphQLFirstPLApp.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphQLFirstPLApp.GraphQlSchema;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQLFirstPLApp.Data.Initialization;

namespace GraphQLFirstPLApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<CarvedRockDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:CarvedRock"]));
            services.AddScoped<ProductRepository>();
            services.AddScoped<ProductReviewRepository>();
            services.AddScoped<IDbInitializer>(s => new DbInitializer(s.GetRequiredService<IServiceScopeFactory>()));
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<CarvedRockSchema>();
            services.AddGraphQL(o => {
                o.ExposeExceptions = Environment.IsDevelopment();
            }).AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader();

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<CarvedRockSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            var dbInit = serviceProvider.GetService<IDbInitializer>();
            dbInit.Init();
        }
    }
}
