using Microsoft.Extensions.Hosting;
using Wolverine;

namespace CQRSAnalyse.WolverineHttp;

public static class WolverineHttpRegistration
{
    public static IHostBuilder AddWolverineHttpServices(this IHostBuilder host)
    {
        host.UseWolverine(options =>
        {
            options.ApplicationAssembly = typeof(WolverineHttpRegistration).Assembly;
            options.Durability.Mode = DurabilityMode.MediatorOnly;
            options.Discovery.IncludeAssembly(typeof(WolverineHttpRegistration).Assembly);
        });
        return host;
    }
}