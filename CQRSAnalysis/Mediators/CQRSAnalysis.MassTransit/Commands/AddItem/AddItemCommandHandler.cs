using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using CQRSAnalysis.Services.Contracts.Services;
using CQRSAnalysis.Services.DataTransferObjects;
using MassTransit;

namespace CQRSAnalysis.MassTransit.Commands.AddItem;

public class AddItemCommandHandler(IInventoryService service) : IConsumer<AddItemCommand>
{
    public async Task Consume(ConsumeContext<AddItemCommand> context)
    {
        var quantity = await service.AddItemAsync(new ItemDto()
        {
            Name = context.Message.Name,
            Quantity = context.Message.Quantity
        }, CancellationToken.None);
        await context.RespondAsync(new AddItemCommandResponse { Quantity = quantity });
    }
}