using Microsoft.Extensions.Hosting;
using Wolverine;

namespace CQRSAnalysis.Wolverine;

public static class WolverineRegistration
{
    public static IHostBuilder AddWolverineServices(this IHostBuilder host)
    {
        host.UseWolverine(options =>
        {
            options.Durability.Mode = DurabilityMode.MediatorOnly;
        });
        return host;
    }
}