using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            InitializeDatabaseAsync(app).GetAwaiter().GetResult();

            return app;
        }

        private static async Task InitializeDatabaseAsync(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<CatalogDbContext>();

            await context.Database.MigrateAsync();
        }
    }
}
