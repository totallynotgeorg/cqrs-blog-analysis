using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using CQRSAnalysis.Services.Contracts.Services;
using CQRSAnalysis.Services.DataTransferObjects;
using Paramore.Darker;

namespace CQRSAnalysis.BrighterDarker.Queries.GetItemList;

public class GetItemListQueryHandler(IInventoryService service) : QueryHandlerAsync<GetItemListQuery, IList<ItemDto>>
{
    public override async Task<IList<ItemDto>> ExecuteAsync(GetItemListQuery query, CancellationToken cancellationToken = new CancellationToken())
    {
        var items = await service.GetItemListAsync(cancellationToken);
        return items;
    }
}