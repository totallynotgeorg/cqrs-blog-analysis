using MassTransit;

namespace CQRSAnalysis.MassTransit.Commands.AddItem;

public class AddItemCommandResponse
{
    public int Quantity { get; set; }
}