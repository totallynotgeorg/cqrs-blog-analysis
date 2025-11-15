using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.DataTransferObjects;

namespace CQRSAnalysis.Services.Contracts.Services;

public interface IInventoryService
{
    Task<List<ItemDto>> GetItemListAsync(CancellationToken cancellationToken);
    Task<int> AddItemAsync(ItemDto item, CancellationToken cancellationToken);
}