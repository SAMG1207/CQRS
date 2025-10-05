using CQRSMediaTr.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediaTr.Infrastructure.Persistance.Repository.BrandRepository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _context;

        public BrandRepository(AppDbContext context) {  _context = context; }

        public void Add(Brand entity)
        {
            _context.AddAsync(entity);
        }

        public void Delete(Brand brand)
        {
            _context.Brands.Remove(brand);
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
            return _context.Brands.AnyAsync(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void Update(Brand entity)
        {
           _context.Brands.Update(entity);
        }
    }
}
