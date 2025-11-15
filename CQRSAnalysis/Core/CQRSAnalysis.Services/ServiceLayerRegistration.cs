using CQRSAnalysis.Services.Contracts;
using CQRSAnalysis.Services.Contracts.Services;
using CQRSAnalysis.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSAnalysis.Services;

public static class ServiceLayerRegistration
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddTransient<IInventoryService, InventoryService>();
        
        return services;
    }
}