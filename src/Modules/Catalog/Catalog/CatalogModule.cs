using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data;

namespace Catalog
{
    public static class CatalogModule
    {
        public static IServiceCollection AddCatalogModule(this IServiceCollection services, 
            IConfiguration configuration)
        {

            // Add services to the container

            // API Endpoint Services

            // Application Use Case Services

            // Data - Infraestructure services
            string connectionString = configuration.GetConnectionString("Database")
                        ?? throw new Exception("Cannot find 'Database' connectionString");

            services.AddDbContext<CatalogDbContext>((options) =>
            {
                options.UseNpgsql(connectionString);
            });
            return services;
        }

        public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
        {
            // Configure HTTP Request Pipeline

            // 1. Use Api Endpoint services

            // 2. Use Application Use Case Services

            // 3. Use Data - Infraestructure services
            app.UseMigration<CatalogDbContext>();

            return app;
        }
               
    }
}
