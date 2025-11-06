using Microsoft.Extensions.Hosting;
using Wolverine;

namespace CQRSAnalysis.Wolverine;

public static class WolverineRegistration
{
    public static IHostBuilder AddWolverineServices(this IHostBuilder host)
    {
        host.UseWolverine(options =>
        {
            options.ApplicationAssembly = typeof(WolverineRegistration).Assembly;
            options.Durability.Mode = DurabilityMode.MediatorOnly;
            options.Discovery.IncludeAssembly(typeof(WolverineRegistration).Assembly);
        });
        return host;
    }
}