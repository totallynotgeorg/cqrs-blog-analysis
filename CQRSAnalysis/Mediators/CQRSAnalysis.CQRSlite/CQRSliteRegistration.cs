using System.Reflection;
using CQRSAnalysis.CQRSlite.Commands.AddItem;
using CQRSAnalysis.CQRSlite.Queries.GetItemList;
using CQRSlite.Caching;
using CQRSlite.Commands;
using CQRSlite.Domain;
using CQRSlite.Events;
using CQRSlite.Messages;
using CQRSlite.Queries;
using CQRSlite.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CQRSAnalysis.CQRSlite;

public static class CQRSliteRegistration
{
    public static IServiceCollection AddCQRSliteServices(this IServiceCollection services)
    {
        services.AddSingleton<Router>(new Router());
        services.AddSingleton<ICommandSender>(y => y.GetService<Router>());
        services.AddSingleton<IEventPublisher>(y => y.GetService<Router>());
        services.AddSingleton<IHandlerRegistrar>(y => y.GetService<Router>());
        services.AddSingleton<IQueryProcessor>(y => y.GetService<Router>());
        services.AddSingleton<IEventStore, InMemoryEventStore>();
        services.AddSingleton<ICache, MemoryCache>();
        services.AddScoped<IRepository>(y => new CacheRepository(new Repository(y.GetService<IEventStore>()), y.GetService<IEventStore>(), y.GetService<ICache>()));
        services.AddScoped<ISession, Session>();
        
        // Command Handler registration
        services.Scan(scan => scan
            .FromAssemblies(typeof(AddItemCommandHandler).GetTypeInfo().Assembly)
            .AddClasses(classes => classes.Where(x =>
            {
                var allInterfaces = x.GetInterfaces();
                return
                    allInterfaces.Any(y =>
                        y.GetTypeInfo().IsGenericType &&
                        y.GetTypeInfo().GetGenericTypeDefinition() == typeof(IHandler<>)) ||
                    allInterfaces.Any(y =>
                        y.GetTypeInfo().IsGenericType &&
                        y.GetTypeInfo().GetGenericTypeDefinition() == typeof(ICancellableHandler<>)) ||
                    allInterfaces.Any(y =>
                        y.GetTypeInfo().IsGenericType &&
                        y.GetTypeInfo().GetGenericTypeDefinition() == typeof(ICommandHandler<>)) ||
                    allInterfaces.Any(y =>
                        y.GetTypeInfo().IsGenericType &&
                        y.GetTypeInfo().GetGenericTypeDefinition() == typeof(IQueryHandler<,>)) ||
                    allInterfaces.Any(y =>
                        y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() ==
                        typeof(ICancellableQueryHandler<,>));
            }))
            .AsSelf()
            .WithTransientLifetime());
        
        return services;
    }

    public static IHost RegisterHandlers(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var provider = scope.ServiceProvider;
        var registrar = provider.GetService<IHandlerRegistrar>();
        var queryHandler = provider.GetService<GetItemListQueryHandler>();
        var commandHandler = provider.GetService<AddItemCommandHandler>();
        
        registrar.RegisterHandler<GetItemListQuery>((query, token) => queryHandler.Handle(query));
        registrar.RegisterHandler<AddItemCommand>((command, token) => commandHandler.Handle(command));
       
        return host;
    }
}