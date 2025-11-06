using MediatR;

namespace CQRSAnalysis.MediatR.Commands.AddItem;

public class AddItemCommand : IRequest<int>
{
    public required string Name { get; init; }
    public int Quantity { get; init; }
}