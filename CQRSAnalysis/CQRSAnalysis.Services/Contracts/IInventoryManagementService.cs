using CQRSAnalysis.Domain;

namespace CQRSAnalysis.Services.Contracts;

public interface IInventoryManagementService
{
    IList<Item> GetItems();
    int AddItem(Item item);
}