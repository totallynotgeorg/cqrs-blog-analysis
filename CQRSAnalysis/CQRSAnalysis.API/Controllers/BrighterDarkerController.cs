using CQRSAnalysis.BrighterDarker.Commands.AddItem;
using CQRSAnalysis.BrighterDarker.Queries.GetItemList;
using Microsoft.AspNetCore.Mvc;
using Paramore.Brighter;
using Paramore.Darker;

namespace CQRSAnalysis.API.Controllers;

[Route("api/brighterdarker")]
[ApiController]
public class BrighterDarkerController(IAmACommandProcessor commandProcessor, IQueryProcessor queryProcessor) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetItemList(CancellationToken cancellationToken)
    {
        var items = await queryProcessor.ExecuteAsync(new GetItemListQuery(), cancellationToken);
        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> AddItem([FromBody] AddItemCommand command, CancellationToken cancellationToken)
    {
        await commandProcessor.SendAsync(command, cancellationToken: cancellationToken);
        return Ok();
    }
}