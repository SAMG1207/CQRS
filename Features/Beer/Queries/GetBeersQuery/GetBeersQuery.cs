using MediatR;

namespace CQRSMediaTr.Features.Beer.Queries.GetBeersQuery
{
    public class GetBeersQuery : IRequest<IEnumerable<Domain.Beer>>
    {
    }
}
