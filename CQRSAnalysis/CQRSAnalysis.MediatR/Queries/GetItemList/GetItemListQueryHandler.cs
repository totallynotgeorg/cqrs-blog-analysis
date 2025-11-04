using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using MediatR;

namespace CQRSAnalysis.MediatR.Queries.GetItemList;

public class GetItemListQueryHandler(IInventoryManagementService service) : IRequestHandler<GetItemListQuery, IList<Item>>
{
    public Task<IList<Item>> Handle(GetItemListQuery request, CancellationToken cancellationToken)
    {
        var items = service.GetItems();
        return Task.FromResult(items);
    }
}