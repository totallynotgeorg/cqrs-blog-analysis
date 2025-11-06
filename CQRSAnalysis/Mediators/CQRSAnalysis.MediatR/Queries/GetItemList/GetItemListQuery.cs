using CQRSAnalysis.Domain;
using MediatR;

namespace CQRSAnalysis.MediatR.Queries.GetItemList;

public class GetItemListQuery : IRequest<IList<Item>>
{
    
}