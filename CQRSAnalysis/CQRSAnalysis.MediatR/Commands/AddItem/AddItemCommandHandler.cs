using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.Contracts;
using MediatR;

namespace CQRSAnalysis.MediatR.Commands.AddItem;

public class AddItemCommandHandler(IInventoryManagementService service) : IRequestHandler<AddItemCommand, int>
{
    public Task<int> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        var quantity = service.AddItem(new Item()
        {
            Name = request.Name,
            Quantity = request.Quantity
        });
        return Task.FromResult(quantity);
    }
}