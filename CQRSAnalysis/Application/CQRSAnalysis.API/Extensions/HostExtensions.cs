using CQRSAnalysis.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CQRSAnalysis.API.Extensions;

public static class HostExtensions
{
    public static async Task ApplyMigrationsAsync(this IHost host, CancellationToken cancellationToken = default)
    {
        using var scope = host.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<InventoryDbContext>();
        
        await context.Database.MigrateAsync(cancellationToken);
    }
}