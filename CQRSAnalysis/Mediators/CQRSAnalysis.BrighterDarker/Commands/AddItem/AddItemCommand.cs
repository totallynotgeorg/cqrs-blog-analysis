using Paramore.Brighter;

namespace CQRSAnalysis.BrighterDarker.Commands.AddItem;

public class AddItemCommand : ICommand
{
    public Id? CorrelationId { get; set; }
    public Id Id { get; set; }
    public required string Name { get; set; }
    public int Quantity { get; set; }
}