using CQRSAnalysis.MassTransit.Commands.AddItem;
using CQRSAnalysis.MassTransit.Queries.GetItemList;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSAnalysis.MassTransit;

public static class MassTransitRegistration
{
    public static IServiceCollection AddMassTransitServices(this IServiceCollection services)
    {
        services.AddMediator(config =>
        {
            config.AddConsumer<GetItemListQueryHandler>();
            config.AddConsumer<AddItemCommandHandler>();
        });
        
        return services;
    }
}