using CQRSMediaTr.Infrastructure.Persistance.UnitOfWork;
using MediatR;

namespace CQRSMediaTr.Features.Brand.Queries.GetBrandsQuery
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IEnumerable<Domain.Brand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetBrandsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Domain.Brand>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BrandRepository.GetAllAsync();
        }
    }
}
