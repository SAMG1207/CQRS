using CQRSMediaTr.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediaTr.Infrastructure.Persistance.Repository.BrandRepository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _context;

        public BrandRepository(AppDbContext context) {  _context = context; }
        public async Task AddAsync(Brand entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(Brand brand)
        {
            _context.Brands.Remove(brand);
            return true;
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await _context.Brands
                .Include(b => b.Beers)
                .ToListAsync();
        }

        public async Task<Brand> GetAsync(int id)
        {
            return await _context.Brands.FindAsync(id);
        }

        public Task<bool> GetBrandByName(string name)
        {
            return _context.Brands.AnyAsync(b => b.Name == name);
        }

        public async Task UpdateAsync(Brand entity)
        {
           _context.Brands.Update(entity);
        }

        Task IRepository<Brand>.DeleteAsync(Brand entity)
        {
            return DeleteAsync(entity);
        }
    }
}
