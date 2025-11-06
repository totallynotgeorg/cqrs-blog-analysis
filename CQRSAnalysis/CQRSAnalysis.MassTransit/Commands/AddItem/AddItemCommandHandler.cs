using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using MassTransit;

namespace CQRSAnalysis.MassTransit.Commands.AddItem;

public class AddItemCommandHandler(IInventoryManagementService service) : IConsumer<AddItemCommand>
{
    public async Task Consume(ConsumeContext<AddItemCommand> context)
    {
        var quantity = service.AddItem(new Item
        {
            Name = context.Message.Name,
            Quantity = context.Message.Quantity
        });
        await context.RespondAsync(new AddItemCommandResponse { Quantity = quantity });
    }
}