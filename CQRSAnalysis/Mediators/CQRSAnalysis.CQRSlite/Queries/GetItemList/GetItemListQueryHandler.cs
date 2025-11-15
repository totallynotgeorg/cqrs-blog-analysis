using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using CQRSAnalysis.Services.Contracts.Services;
using CQRSAnalysis.Services.DataTransferObjects;
using CQRSlite.Queries;

namespace CQRSAnalysis.CQRSlite.Queries.GetItemList;

public class GetItemListQueryHandler(IInventoryService service) : IQueryHandler<GetItemListQuery, IList<ItemDto>>
{
    public async Task<IList<ItemDto>> Handle(GetItemListQuery query)
    {
        var items = await service.GetItemListAsync(CancellationToken.None);
        return items;
    }
}