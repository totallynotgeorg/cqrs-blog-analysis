using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;

namespace CQRSAnalysis.Wolverine.Queries.GetItemList;

public class GetItemListQueryHandler
{
    public static Task<IList<Item>> Handle(GetItemListQuery getItemListQuery, IInventoryManagementService service, CancellationToken cancellationToken)
    {
        var items = service.GetItems();
        return Task.FromResult(items);
    }
}