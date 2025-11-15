using CQRSAnalysis.Domain;
using CQRSAnalysis.Services.DataTransferObjects;
using MediatR;

namespace CQRSAnalysis.MediatR.Queries.GetItemList;

public class GetItemListQuery : IRequest<IList<ItemDto>>
{
    
}