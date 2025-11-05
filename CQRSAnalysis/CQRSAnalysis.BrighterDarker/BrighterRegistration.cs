using CQRSAnalysis.BrighterDarker.Queries.GetItemList;
using Microsoft.Extensions.DependencyInjection;
using Paramore.Brighter.Extensions.DependencyInjection;
using Paramore.Darker.AspNetCore;

namespace CQRSAnalysis.BrighterDarker;

public static class BrighterDarkerRegistration
{
    public static IServiceCollection AddBrighterDarkerServices(this IServiceCollection services)
    {
        services.AddBrighter(options =>
            {
                options.HandlerLifetime = ServiceLifetime.Transient;
                options.MapperLifetime = ServiceLifetime.Transient;
            })
            .AutoFromAssemblies(new[] { typeof(GetItemListQuery).Assembly });

        services.AddDarker(options =>
        {
            options.HandlerLifetime = ServiceLifetime.Transient;
            options.QueryProcessorLifetime = ServiceLifetime.Transient;
        })
        .AddHandlersFromAssemblies(new []{ typeof(GetItemListQuery).Assembly });
        
        return services;
    }
}