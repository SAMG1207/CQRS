using CQRSMediaTr.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediaTr.Infrastructure.Persistance.Repository.BeerRepository
{
    public class BeerRepository : IBeerRepository
    {
        private readonly AppDbContext _context;

        public BeerRepository(AppDbContext context) { _context = context; }
        public async Task AddAsync(Beer entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task DeleteAsync(Beer entity)
        {
            _context.Beers.Remove(entity);
        }

        public async Task<IEnumerable<Beer>> GetAllAsync()
        {
            return await _context.Beers.ToListAsync();
        }

        public async Task<Beer?> GetAsync(int id)
        {
            return await _context.Beers.FindAsync(id);
        }

        public async Task<bool> GetBeerByNameAndBrandId(string beerName, int brandId)
        {
            return await _context.Beers.AnyAsync(b => b.Name.ToLower() ==  beerName.ToLower() && b.BrandId == brandId);
        }

        public async Task UpdateAsync(Beer entity)
        {
            _context.Beers.Update(entity);
        }
    }
}
