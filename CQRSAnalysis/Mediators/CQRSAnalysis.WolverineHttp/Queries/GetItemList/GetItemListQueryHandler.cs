using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;

namespace CQRSAnalysis.WolverineHttp.Queries.GetItemList;

public class GetItemListQueryHandler
{
    public static Task<GetItemListQueryResponse> Handle(GetItemListQuery getItemListQuery, IInventoryManagementService service, CancellationToken cancellationToken)
    {
        var items = service.GetItems();
        return Task.FromResult(new GetItemListQueryResponse(){ Items = items });
    }
}