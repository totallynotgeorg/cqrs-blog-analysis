using CQRSAnalysis.Services.Contracts;
using MassTransit;

namespace CQRSAnalysis.MassTransit.Queries.GetItemList;

public class GetItemListQueryHandler(IInventoryManagementService service) : IConsumer<GetItemListQuery>
{
    public async Task Consume(ConsumeContext<GetItemListQuery> context)
    {
        var items = service.GetItems();
        await context.RespondAsync(new GetItemListQueryResponse{ Items = items });
    }
}