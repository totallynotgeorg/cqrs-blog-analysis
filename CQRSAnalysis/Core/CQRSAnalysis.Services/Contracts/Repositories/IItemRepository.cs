using CQRSAnalysis.Domain;

namespace CQRSAnalysis.Services.Contracts.Repositories;

public interface IItemRepository
{
    IQueryable<Item> GetItemList();
    Task AddItemAsync(Item item, CancellationToken cancellationToken);
}