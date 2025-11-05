using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using CQRSlite.Queries;

namespace CQRSAnalysis.CQRSlite.Queries.GetItemList;

public class GetItemListQueryHandler(IInventoryManagementService service) : IQueryHandler<GetItemListQuery, IList<Item>>
{
    public Task<IList<Item>> Handle(GetItemListQuery query)
    {
        return Task.FromResult(service.GetItems());
    }
}