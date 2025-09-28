using CQRSMediaTr.Exceptions.Beer;
using CQRSMediaTr.Infrastructure.Persistance.UnitOfWork;
using MediatR;

namespace CQRSMediaTr.Features.Beer.Queries.GetBeerByIdQuery
{
    public class GetBeerByQueryHandler : IRequestHandler<GetBeerByIdQuery, Domain.Beer>
    {
        private readonly IUnitOfWork _unitOFWork;
        public GetBeerByQueryHandler(IUnitOfWork unitOFWork)
        {
           _unitOFWork = unitOFWork;
        }
        public async Task<Domain.Beer> Handle(GetBeerByIdQuery request, CancellationToken cancellationToken)
        {
            var beer = await _unitOFWork.BeerRepository.GetAsync(request.Id);
            if(beer == null)
            {
                throw new BeerNotFoundException(request.Id);
            }
            return beer;
        }
    }
}
