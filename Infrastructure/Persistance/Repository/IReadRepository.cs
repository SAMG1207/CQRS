namespace CQRSMediaTr.Infrastructure.Persistance.Repository.BrandRepository
{
    public interface IReadRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
    }
}
