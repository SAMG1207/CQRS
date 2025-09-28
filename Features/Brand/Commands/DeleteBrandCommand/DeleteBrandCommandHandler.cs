using CQRSMediaTr.Exceptions.Brands;
using CQRSMediaTr.Infrastructure.Persistance.UnitOfWork;
using MediatR;

namespace CQRSMediaTr.Features.Brand.Commands.DeleteBrandCommand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBrandCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _unitOfWork.BrandRepository.GetAsync(request.Id) ?? throw new BrandNotFoundException(request.Id);
            await _unitOfWork.BrandRepository.DeleteAsync(brand);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
