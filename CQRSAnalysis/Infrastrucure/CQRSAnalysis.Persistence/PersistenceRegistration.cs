using CQRSAnalysis.Persistence.Data;
using CQRSAnalysis.Persistence.Repositories;
using CQRSAnalysis.Services.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSAnalysis.Persistence;

public static class PersistenceRegistration
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<InventoryDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddTransient<IItemRepository, ItemRepository>();
        
        return services;
    }
}