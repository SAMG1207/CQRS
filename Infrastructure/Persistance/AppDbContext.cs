using CQRSMediaTr.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediaTr.Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public DbSet<Beer> Beers { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Beers)
                .WithOne(b => b.Brand!)
                .HasForeignKey(b => b.BrandId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
