using CQRSMediaTr.Domain;

namespace CQRSMediaTr.Infrastructure.Persistance.Repository.BeerRepository
{
    public interface IBeerRepository : IRepository<Beer>
    {
        Task <bool> GetBeerByNameAndBrandId (string beerName, int brandId);
    }
}
