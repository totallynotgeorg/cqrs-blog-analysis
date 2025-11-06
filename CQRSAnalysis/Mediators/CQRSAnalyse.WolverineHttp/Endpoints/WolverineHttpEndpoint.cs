using CQRSAnalyse.WolverineHttp.Commands.AddItem;
using CQRSAnalyse.WolverineHttp.Queries.GetItemList;
using Wolverine;
using Wolverine.Http;

namespace CQRSAnalyse.WolverineHttp.Endpoints;

public class WolverineHttpEndpoint(IMessageBus messageBus)
{
    [WolverineGet("/api/wolverinehttp")]
    public async Task<GetItemListQueryResponse> GetItemList(CancellationToken cancellationToken)
    {
        var response = await messageBus.InvokeAsync<GetItemListQueryResponse>(new GetItemListQuery(), cancellationToken);
        return response;
    }
    
    [WolverinePost("/api/wolverinehttp")]
    public async Task<AddItemCommandResponse> AddItem(AddItemCommand command, CancellationToken cancellationToken)
    {
        var response = await messageBus.InvokeAsync<AddItemCommandResponse>(command, cancellationToken);
        return response;
    }
}