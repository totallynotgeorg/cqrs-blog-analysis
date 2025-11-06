using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;

namespace CQRSAnalysis.WolverineHttp.Commands.AddItem;

public class AddItemCommandHandler
{
    public static Task<AddItemCommandResponse> Handle(AddItemCommand request, IInventoryManagementService service, CancellationToken cancellationToken)
    {
        var quantity = service.AddItem(new Item
        {
            Name = request.Name,
            Quantity = request.Quantity
        });
        return Task.FromResult(new AddItemCommandResponse(quantity));
    }
}