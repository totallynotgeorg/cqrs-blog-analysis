using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.DataTransferObjects;

namespace CQRSAnalysis.WolverineHttp.Queries.GetItemList;

public class GetItemListQueryResponse
{
    public IList<ItemDto> Items { get; set; }
}