using Wolverine.Http;

namespace CQRSAnalyse.WolverineHttp.Commands.AddItem;

public record AddItemCommandResponse : CreationResponse<int>
{
    public AddItemCommandResponse(int quantity) : base("/api/wolverinehttp", quantity) { }
}