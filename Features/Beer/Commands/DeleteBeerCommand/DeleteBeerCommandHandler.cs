using CQRSMediaTr.Exceptions.Beer;
using CQRSMediaTr.Infrastructure.Persistance.UnitOfWork;
using MediatR;

namespace CQRSMediaTr.Features.Beer.Commands.DeleteBeerCommand
{
    public class DeleteBeerCommandHandler : IRequestHandler<DeleteBeerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBeerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteBeerCommand request, CancellationToken cancellationToken)
        {
            var beer = await _unitOfWork.BeerRepository.GetAsync(request.Id) ?? throw new BeerNotFoundException(request.Id);
            _unitOfWork.BeerRepository.Delete(beer);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
