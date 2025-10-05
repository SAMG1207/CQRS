using CQRSMediaTr.Exceptions.Brands;
using CQRSMediaTr.Infrastructure.Persistance.UnitOfWork;
using MediatR;

namespace CQRSMediaTr.Features.Brand.Commands.Updating
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBrandCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _unitOfWork.BrandRepository.GetAsync(request.Id) ?? throw new BrandNotFoundException(request.Id);
            bool brandAlreadyExists = await _unitOfWork.BrandRepository.GetBrandByName(request.Name);
            if (brandAlreadyExists)
            {
                throw new BrandAlreadyExistsException(request.Name);
            }
            brand.Name = request.Name;
            _unitOfWork.BrandRepository.Update(brand);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
