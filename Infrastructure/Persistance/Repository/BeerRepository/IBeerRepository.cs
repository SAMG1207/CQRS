using CQRSMediaTr.Domain;
using CQRSMediaTr.Infrastructure.Persistance.Repository.BrandRepository;

namespace CQRSMediaTr.Infrastructure.Persistance.Repository.BeerRepository
{
    public interface IBeerRepository : IRepository<Beer>, IReadRepository<Beer>
    {
        Task <bool> GetBeerByNameAndBrandId (string beerName, int brandId);
    }
}
