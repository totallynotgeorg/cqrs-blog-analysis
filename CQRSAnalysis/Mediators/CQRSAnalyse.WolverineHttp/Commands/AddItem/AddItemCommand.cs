namespace CQRSAnalyse.WolverineHttp.Commands.AddItem;

public class AddItemCommand
{
    public required string Name { get; set; }
    public int Quantity { get; set; }
}