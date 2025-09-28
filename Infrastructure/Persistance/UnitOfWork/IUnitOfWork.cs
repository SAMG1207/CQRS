using CQRSMediaTr.Domain;
using CQRSMediaTr.Infrastructure.Persistance.Repository;
using CQRSMediaTr.Infrastructure.Persistance.Repository.BeerRepository;
using CQRSMediaTr.Infrastructure.Persistance.Repository.BrandRepository;

namespace CQRSMediaTr.Infrastructure.Persistance.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBeerRepository BeerRepository { get; }
        IBrandRepository BrandRepository { get; }
        Task<int> SaveChangesAsync();
        /*
         * It uses Task<int> because int represents the number of operations done 
         */
    }
}
