using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;

namespace CQRSAnalysis.Services.Services;

public class InventoryManagementService : IInventoryManagementService
{
    private IList<Item> Items { get; init; } = new List<Item>();
    
    public IList<Item> GetItems()
    {
        return Items;
    }
    
    public int AddItem(Item? item)
    {
        if (item is null)
            return -1;
        
        if (Items.Any(x => x.Name == item.Name))
            return -1;
        
        Items.Add(item);
        return item.Quantity;
    }
}