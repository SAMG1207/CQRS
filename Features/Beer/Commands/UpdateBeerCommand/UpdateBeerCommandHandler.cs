using CQRSMediaTr.Exceptions.Beer;
using CQRSMediaTr.Exceptions.Brands;
using CQRSMediaTr.Infrastructure.Persistance.UnitOfWork;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace CQRSMediaTr.Features.Beer.Commands.Updating
{
    public class UpdateBeerCommandHandler : IRequestHandler<UpdateBeerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOFWork;

        public UpdateBeerCommandHandler(IUnitOfWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        }

        public async Task<Unit> Handle(UpdateBeerCommand request, CancellationToken cancellationToken)
        {
           var beer = await _unitOFWork.BeerRepository.GetAsync(request.Id) ?? throw new BeerNotFoundException(request.Id);
           _ = await _unitOFWork.BrandRepository.GetAsync(request.BrandId) ?? throw new BrandNotFoundException(request.BrandId);

           beer.BrandId = request.BrandId;
           beer.Name = request.Name;
            
            _unitOFWork.BeerRepository.Update(beer);
            await _unitOFWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
