using CQRSMediaTr.Exceptions.Beer;
using CQRSMediaTr.Exceptions.Brands;
using CQRSMediaTr.Infrastructure.Persistance.UnitOfWork;
using MediatR;

namespace CQRSMediaTr.Features.Beer.Commands.Adding
{
    public class AddBeerCommandHandler : IRequestHandler<AddBeerCommand, Domain.Beer>
    {
        private readonly IUnitOfWork _unitOFWork;
        public AddBeerCommandHandler(IUnitOfWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        }
        public async Task<Domain.Beer> Handle(AddBeerCommand request, CancellationToken cancellationToken)
        {
            bool beerAlreadyExists = await _unitOFWork.BeerRepository.GetBeerByNameAndBrandId(request.Name, request.BrandId);
            if (beerAlreadyExists){
                throw new BeerAlreadyExistsInThisBrandException(request.Name);
            }
            var beer = new Domain.Beer(request.BrandId, request.Name);
            _ = await _unitOFWork.BrandRepository.GetAsync(beer.BrandId) ?? throw new BrandNotFoundException(beer.BrandId);

            await _unitOFWork.BeerRepository.AddAsync(beer);
            await _unitOFWork.SaveChangesAsync();
            return beer;
        }
    }
}
