using CQRSMediaTr.Infrastructure.Persistance.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace CQRSMediaTr.Features.Brand.Queries.GetBrandsQuery
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IEnumerable<Domain.Brand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;
        public GetBrandsQueryHandler(IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<IEnumerable<Domain.Brand>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            const string cacheKey = "brands_all";
            var stopwatch = Stopwatch.StartNew();
            if (_cache.TryGetValue(cacheKey, out IEnumerable<Domain.Brand> cachedBrands))
            {
                stopwatch.Stop();
                Console.WriteLine($"Tiempo de respuesta (desde caché): {stopwatch.ElapsedMilliseconds} ms");
                return cachedBrands;
            }
            Console.WriteLine("Checking DB");
            var brands = await _unitOfWork.BrandRepository.GetAllAsync();
            var cachedOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };
            _cache.Set(cacheKey, brands, cachedOptions);
            stopwatch.Stop();
            Console.WriteLine($"Tiempo de respuesta (desde BD): {stopwatch.ElapsedMilliseconds} ms");
            return brands;
        }
    }
}
