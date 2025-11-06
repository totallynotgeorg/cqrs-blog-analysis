using CQRSAnalysis.Domain;

namespace CQRSAnalyse.WolverineHttp.Queries.GetItemList;

public class GetItemListQueryResponse
{
    public IList<Item> Items { get; set; }
}