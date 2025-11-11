using CQRSMediaTr.Domain;

namespace CQRSMediaTr.Infrastructure.Persistance.Repository.BrandRepository
{
    public interface IBrandRepository : IRepository<Brand>, IReadRepository<Brand>
    {
        Task<bool> GetBrandByName(string name);
    }
}
