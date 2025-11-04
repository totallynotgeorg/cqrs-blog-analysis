using CQRSAnalysis.Domain;
using CQRSAnalysis.MediatR.Commands.AddItem;
using CQRSAnalysis.MediatR.Queries.GetItemList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAnalysis.API.Controllers;

[Route("api/mediatr")]
[ApiController]
public class MediatRItemController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetItems(CancellationToken cancellationToken)
    {
        var items = await mediator.Send(new GetItemListQuery(), cancellationToken);
        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> AddItem(AddItemCommand command, CancellationToken cancellationToken)
    {
        var quantity = await mediator.Send(command, cancellationToken);
        return Ok(quantity);
    }
}