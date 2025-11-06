using MassTransit.Mediator;

namespace CQRSAnalysis.MassTransit.Commands.AddItem;

public class AddItemCommand : Request<AddItemCommandResponse>
{
    public required string Name { get; set; }
    public int Quantity { get; set; }
}