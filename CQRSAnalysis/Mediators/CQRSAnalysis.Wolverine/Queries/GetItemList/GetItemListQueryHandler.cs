using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using CQRSAnalysis.Services.Contracts.Services;
using CQRSAnalysis.Services.DataTransferObjects;

namespace CQRSAnalysis.Wolverine.Queries.GetItemList;

public class GetItemListQueryHandler
{
    public static async Task<IList<ItemDto>> Handle(GetItemListQuery getItemListQuery, IInventoryService service, CancellationToken cancellationToken)
    {
        var items = await service.GetItemListAsync(cancellationToken);
        return items;
    }
}