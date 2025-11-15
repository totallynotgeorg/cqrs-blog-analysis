using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using CQRSAnalysis.Services.Contracts.Services;
using CQRSAnalysis.Services.DataTransferObjects;
using MediatR;

namespace CQRSAnalysis.MediatR.Commands.AddItem;

public class AddItemCommandHandler(IInventoryService service) : IRequestHandler<AddItemCommand, int>
{
    public async Task<int> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        var quantity = await service.AddItemAsync(new ItemDto()
        {
            Name = request.Name,
            Quantity = request.Quantity
        }, cancellationToken);
        return quantity;
    }
}