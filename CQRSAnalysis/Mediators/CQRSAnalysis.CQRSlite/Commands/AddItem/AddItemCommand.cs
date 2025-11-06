using CQRSlite.Commands;

namespace CQRSAnalysis.CQRSlite.Commands.AddItem;

public class AddItemCommand : ICommand
{
    public required string Name { get; set; }
    public int Quantity { get; set; }
}