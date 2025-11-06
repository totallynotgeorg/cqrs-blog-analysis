using CQRSAnalysis.Domain;
using CQRSAnalysis.MassTransit.Commands.AddItem;
using CQRSAnalysis.MassTransit.Queries.GetItemList;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAnalysis.API.Controllers;

[Route("api/masstransit")]
[ApiController]
public class MassTransitItemController(IMediator mediator) : ControllerBase
{
    public async Task<IActionResult> GetItemList(CancellationToken cancellationToken)
    {
        var client = mediator.CreateRequestClient<GetItemListQuery>();
        var response = await client.GetResponse<GetItemListQueryResponse>(new GetItemListQuery(), cancellationToken);
        return Ok(response.Message.Items);
    }

    [HttpPost]
    public async Task<IActionResult> AddItem(AddItemCommand command, CancellationToken cancellationToken)
    {
        var client = mediator.CreateRequestClient<AddItemCommand>();
        var response = await client.GetResponse<AddItemCommandResponse>(command, cancellationToken: cancellationToken);
        return Ok(response.Message.Quantity);
    }
}