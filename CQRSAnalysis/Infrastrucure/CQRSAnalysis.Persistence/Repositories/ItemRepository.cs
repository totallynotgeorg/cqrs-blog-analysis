using CQRSAnalysis.Domain;
using CQRSAnalysis.Persistence.Data;
using CQRSAnalysis.Services.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CQRSAnalysis.Persistence.Repositories;

public class ItemRepository(InventoryDbContext context) : IItemRepository
{
    public IQueryable<Item> GetItemList() => context.Items.AsQueryable().AsNoTracking();

    public async Task AddItemAsync(Item item, CancellationToken cancellationToken)
    {
        context.Items.Add(item);
        await context.SaveChangesAsync(cancellationToken);
    }
}