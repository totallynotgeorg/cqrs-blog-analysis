using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using CQRSlite.Commands;
using CQRSlite.Domain;

namespace CQRSAnalysis.CQRSlite.Commands.AddItem;

public class AddItemCommandHandler(ISession session, IInventoryManagementService service) : ICommandHandler<AddItemCommand>
{
    public Task Handle(AddItemCommand message)
    {
        service.AddItem(new Item
        {
            Name =  message.Name,
            Quantity = message.Quantity
        });
        return Task.CompletedTask;
    }
}