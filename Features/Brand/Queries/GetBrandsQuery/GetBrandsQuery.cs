using MediatR;

namespace CQRSMediaTr.Features.Brand.Queries.GetBrandsQuery
{
    public class GetBrandsQuery : IRequest<IEnumerable<Domain.Brand>>
    {
    }
}
