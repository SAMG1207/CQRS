using MediatR;

namespace CQRSMediaTr.Features.Beer.Queries.GetBeerByIdQuery
{
    public class GetBeerByIdQuery : IRequest<Domain.Beer>
    {
        public int Id { get; set; }
    }
}
