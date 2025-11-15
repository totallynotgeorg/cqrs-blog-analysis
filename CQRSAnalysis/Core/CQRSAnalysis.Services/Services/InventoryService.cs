using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts.Repositories;
using CQRSAnalysis.Services.Contracts.Services;
using CQRSAnalysis.Services.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace CQRSAnalysis.Services.Services;

public class InventoryService(IItemRepository itemRepository) : IInventoryService
{
    public Task<List<ItemDto>> GetItemListAsync(CancellationToken cancellationToken)
    {
        var itemQuery = itemRepository.GetItemList();
        return itemQuery.Select(x => new ItemDto(){ Name =  x.Name, Quantity = x.Quantity }).ToListAsync(cancellationToken);
    }

    public async Task<int> AddItemAsync(ItemDto item, CancellationToken cancellationToken)
    {
        var entity = new Item()
        {
            Name = item.Name,
            Quantity = item.Quantity
        };
        await itemRepository.AddItemAsync(entity, cancellationToken);
        return item.Quantity;
    }
}