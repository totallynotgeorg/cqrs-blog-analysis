using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using CQRSAnalysis.Services.Contracts.Services;
using CQRSAnalysis.Services.DataTransferObjects;
using CQRSlite.Commands;
using CQRSlite.Domain;

namespace CQRSAnalysis.CQRSlite.Commands.AddItem;

public class AddItemCommandHandler(ISession session, IInventoryService service) : ICommandHandler<AddItemCommand>
{
    public async Task Handle(AddItemCommand message)
    {
        await service.AddItemAsync(new ItemDto()
        {
            Name =  message.Name,
            Quantity = message.Quantity
        }, CancellationToken.None);
    }
}