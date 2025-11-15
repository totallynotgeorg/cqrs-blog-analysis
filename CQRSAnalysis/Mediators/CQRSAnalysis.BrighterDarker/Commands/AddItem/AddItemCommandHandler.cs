using CQRSAnalysis.Services.Contracts.Services;
using CQRSAnalysis.Services.DataTransferObjects;
using Paramore.Brighter;

namespace CQRSAnalysis.BrighterDarker.Commands.AddItem;

public class AddItemCommandHandler(IInventoryService service) : RequestHandlerAsync<AddItemCommand>
{
    public override async Task<AddItemCommand> HandleAsync(AddItemCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        await service.AddItemAsync(new ItemDto()
        {
            Name = command.Name,
            Quantity = command.Quantity
        }, cancellationToken);
        return await base.HandleAsync(command, cancellationToken);
    }
}