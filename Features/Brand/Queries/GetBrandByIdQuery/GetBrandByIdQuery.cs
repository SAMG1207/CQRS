using CQRSMediaTr.Domain;
using MediatR;

namespace CQRSMediaTr.Features.Brand.Queries.GetBrandByIdQuery
{
    public class GetBrandByIdQuery : IRequest<Domain.Brand>
    {
        public int Id { get; set; }
    }
}
