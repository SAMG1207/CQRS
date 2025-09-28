using CQRSMediaTr.Infrastructure.Persistance.UnitOfWork;
using MediatR;

namespace CQRSMediaTr.Features.Beer.Queries.GetBeersQuery
{
    public class GetBeersQueryHandler : IRequestHandler<GetBeersQuery, IEnumerable<Domain.Beer>>
    {   
        private readonly IUnitOfWork _unitOfWork;
        public GetBeersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Domain.Beer>> Handle(GetBeersQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.BeerRepository.GetAllAsync();
        }
    }
}
