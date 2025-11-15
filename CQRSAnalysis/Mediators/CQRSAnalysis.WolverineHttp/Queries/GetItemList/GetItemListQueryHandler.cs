using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using CQRSAnalysis.Services.Contracts.Services;

namespace CQRSAnalysis.WolverineHttp.Queries.GetItemList;

public class GetItemListQueryHandler
{
    public static async Task<GetItemListQueryResponse> Handle(GetItemListQuery getItemListQuery, IInventoryService service, CancellationToken cancellationToken)
    {
        var items = await service.GetItemListAsync(cancellationToken);
        return new GetItemListQueryResponse(){ Items = items };
    }
}