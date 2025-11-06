using CQRSAnalysis.CQRSlite.Commands.AddItem;
using CQRSAnalysis.CQRSlite.Queries.GetItemList;
using CQRSlite.Commands;
using CQRSlite.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAnalysis.API.Controllers;

[Route("api/cqrslite")]
[ApiController]
public class CQRSliteController(ICommandSender commandSender, IQueryProcessor queryProcessor) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetItemList(CancellationToken cancellationToken)
    {
        var items = await queryProcessor.Query(new GetItemListQuery(), cancellationToken);
        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> AddItem([FromBody] AddItemCommand command, CancellationToken cancellationToken)
    {
        await commandSender.Send(command, cancellationToken);
        return Ok();
    }
}