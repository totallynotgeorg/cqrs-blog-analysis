// using CQRSAnalysis.Domain;
// using CQRSAnalysis.Wolverine.Commands.AddItem;
// using CQRSAnalysis.Wolverine.Queries.GetItemList;
// using Microsoft.AspNetCore.Mvc;
// using Wolverine;
//
// namespace CQRSAnalysis.API.Controllers;
//
// [Route("api/wolverine")]
// [ApiController]
// public class WolverineItemController(IMessageBus messageBus) : ControllerBase
// {
//     [HttpGet]
//     public async Task<IActionResult> GetItemList(CancellationToken cancellationToken)
//     {
//         var items = await messageBus.InvokeAsync<IList<Item>>(new GetItemListQuery(), cancellationToken);
//         return Ok(items);
//     }
//
//     [HttpPost]
//     public async Task<IActionResult> AddItem(AddItemCommand command, CancellationToken cancellationToken)
//     {
//         var quantity = await messageBus.InvokeAsync<int>(command, cancellationToken);
//         return Ok(quantity);
//     }
// }