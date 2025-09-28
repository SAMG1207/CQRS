using CQRSMediaTr.Exceptions.Brands;
using CQRSMediaTr.Infrastructure.Persistance.UnitOfWork;
using MediatR;

namespace CQRSMediaTr.Features.Brand.Commands.Adding
{
    public class AddBrandCommandHandler : IRequestHandler<AddBrandCommand, Domain.Brand>
    {
        private readonly IUnitOfWork _unitOFWork;

        public AddBrandCommandHandler(IUnitOfWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        }
        public async Task<Domain.Brand> Handle(AddBrandCommand request, CancellationToken cancellationToken)
        {
            if(await _unitOFWork.BrandRepository.GetBrandByName(request.Name))
            {
                throw new BrandAlreadyExistsException(request.Name);
            }

            var brand = new Domain.Brand(request.Name);
            await _unitOFWork.BrandRepository.AddAsync(brand);
            await _unitOFWork.SaveChangesAsync();
            return brand;
        }
    }
}
