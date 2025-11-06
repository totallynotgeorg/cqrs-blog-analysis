using CQRSAnalysis.Domain;

namespace CQRSAnalysis.WolverineHttp.Queries.GetItemList;

public class GetItemListQueryResponse
{
    public IList<Item> Items { get; set; }
}