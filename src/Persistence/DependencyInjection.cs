using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // build connection string
            var builder = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("Database"))
            {
                Password = configuration["mobiele-db-password"]
            };
            
            services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(builder.ConnectionString));
            
            services.AddScoped<IRepository>(sp => sp.GetService<DatabaseContext>());
            
            return services;
        }
    }
}