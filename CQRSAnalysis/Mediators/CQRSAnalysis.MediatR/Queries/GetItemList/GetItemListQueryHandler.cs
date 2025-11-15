using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using CQRSAnalysis.Services.Contracts.Services;
using CQRSAnalysis.Services.DataTransferObjects;
using MediatR;

namespace CQRSAnalysis.MediatR.Queries.GetItemList;

public class GetItemListQueryHandler(IInventoryService service) : IRequestHandler<GetItemListQuery, IList<ItemDto>>
{
    public async Task<IList<ItemDto>> Handle(GetItemListQuery request, CancellationToken cancellationToken)
    {
        var items = await service.GetItemListAsync(cancellationToken);
        return items;
    }
}