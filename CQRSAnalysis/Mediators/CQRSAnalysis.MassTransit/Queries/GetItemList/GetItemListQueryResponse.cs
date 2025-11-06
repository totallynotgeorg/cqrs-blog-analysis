using CQRSAnalysis.Domain;

namespace CQRSAnalysis.MassTransit.Queries.GetItemList;

public class GetItemListQueryResponse
{
    public IList<Item> Items { get; set; }
}