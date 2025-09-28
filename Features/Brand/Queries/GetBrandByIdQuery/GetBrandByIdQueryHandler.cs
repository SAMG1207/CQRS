using CQRSMediaTr.Exceptions.Brands;
using CQRSMediaTr.Infrastructure.Persistance.UnitOfWork;
using MediatR;

namespace CQRSMediaTr.Features.Brand.Queries.GetBrandByIdQuery
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Domain.Brand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public  GetBrandByIdQueryHandler(IUnitOfWork unitOFWork)
        {
            _unitOfWork = unitOFWork;
        }
        public Task<Domain.Brand> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.BrandRepository.GetAsync(request.Id) ?? throw new BrandNotFoundException(request.Id);
        }
    }
}
