using Microsoft.Extensions.DependencyInjection;

namespace CQRSAnalysis.MediatR;

public static class MediatRRegistration
{
    public static IServiceCollection AddMediatRServices(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(MediatRRegistration).Assembly);
        });
        
        return services;
    }
}