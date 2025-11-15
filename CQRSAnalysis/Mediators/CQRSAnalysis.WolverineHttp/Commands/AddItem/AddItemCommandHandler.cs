using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using CQRSAnalysis.Services.Contracts.Services;
using CQRSAnalysis.Services.DataTransferObjects;

namespace CQRSAnalysis.WolverineHttp.Commands.AddItem;

public class AddItemCommandHandler
{
    public static async Task<AddItemCommandResponse> Handle(AddItemCommand request, IInventoryService service, CancellationToken cancellationToken)
    {
        var quantity = await service.AddItemAsync(new ItemDto
        {
            Name = request.Name,
            Quantity = request.Quantity
        }, cancellationToken);
        return new AddItemCommandResponse(quantity);
    }
}