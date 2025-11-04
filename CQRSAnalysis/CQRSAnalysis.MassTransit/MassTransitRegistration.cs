using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSAnalysis.MassTransit;

public static class MassTransitRegistration
{
    public static IServiceCollection AddMassTransitServices(this IServiceCollection services)
    {
        services.AddMediator();
        
        return services;
    }
}