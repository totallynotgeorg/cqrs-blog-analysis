using CQRSAnalysis.Services.Contracts;
using CQRSAnalysis.Services.Contracts.Services;
using MassTransit;

namespace CQRSAnalysis.MassTransit.Queries.GetItemList;

public class GetItemListQueryHandler(IInventoryService service) : IConsumer<GetItemListQuery>
{
    public async Task Consume(ConsumeContext<GetItemListQuery> context)
    {
        var items = await service.GetItemListAsync(CancellationToken.None);
        await context.RespondAsync(new GetItemListQueryResponse{ Items = items });
    }
}