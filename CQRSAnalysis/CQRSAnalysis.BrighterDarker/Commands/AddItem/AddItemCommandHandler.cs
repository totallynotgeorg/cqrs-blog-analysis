using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using Paramore.Brighter;

namespace CQRSAnalysis.BrighterDarker.Commands.AddItem;

public class AddItemCommandHandler(IInventoryManagementService service) : RequestHandlerAsync<AddItemCommand>
{
    public override Task<AddItemCommand> HandleAsync(AddItemCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        service.AddItem(new Item
        {
            Name = command.Name,
            Quantity = command.Quantity
        });
        return base.HandleAsync(command, cancellationToken);
    }
}