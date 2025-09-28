using CQRSMediaTr.Infrastructure.Persistance.Repository.BeerRepository;
using CQRSMediaTr.Infrastructure.Persistance.Repository.BrandRepository;

namespace CQRSMediaTr.Infrastructure.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _appDbContext;
  
        public IBeerRepository BeerRepository { get; }

        public IBrandRepository BrandRepository { get; }

        public UnitOfWork(AppDbContext appDbContext, IBrandRepository brandRepository, IBeerRepository beerRepository)
        {
            _appDbContext = appDbContext;
            BeerRepository = beerRepository;
            BrandRepository = brandRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
