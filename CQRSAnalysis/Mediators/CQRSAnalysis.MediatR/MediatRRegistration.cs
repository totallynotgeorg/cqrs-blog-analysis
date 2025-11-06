using Microsoft.Extensions.DependencyInjection;

namespace CQRSAnalysis.MediatR;

public static class MediatRRegistration
{
    public static IServiceCollection AddMediatRServices(this IServiceCollection services, string licenseKey)
    {
        services.AddMediatR(config =>
        {
            config.LicenseKey = licenseKey;
            config.RegisterServicesFromAssembly(typeof(MediatRRegistration).Assembly);
        });
        
        return services;
    }
}