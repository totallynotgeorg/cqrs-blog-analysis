using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using Paramore.Darker;

namespace CQRSAnalysis.BrighterDarker.Queries.GetItemList;

public class GetItemListQueryHandler(IInventoryManagementService service) : QueryHandlerAsync<GetItemListQuery, IList<Item>>
{
    public override Task<IList<Item>> ExecuteAsync(GetItemListQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var items = service.GetItems();
        return Task.FromResult(items);
    }
}