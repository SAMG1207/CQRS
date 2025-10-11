using CQRSMediaTr.Infrastructure.Persistance.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Diagnostics;

namespace CQRSMediaTr.Features.Beer.Queries.GetBeersQuery
{
    public class GetBeersQueryHandler : IRequestHandler<GetBeersQuery, IEnumerable<Domain.Beer>>
    {   
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;
        public GetBeersQueryHandler(IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }
        public async Task<IEnumerable<Domain.Beer>> Handle(GetBeersQuery request, CancellationToken cancellationToken)
        {
            const string cacheKey = "beers_all";
            var stopwatch = Stopwatch.StartNew();
            if (_cache.TryGetValue(cacheKey, out IEnumerable<Domain.Beer> cachedBeers))
            {
                stopwatch.Stop();
                Console.WriteLine($"Tiempo de respuesta (desde caché): {stopwatch.ElapsedMilliseconds} ms");
                return cachedBeers;
            }
            Console.WriteLine("Checking DB");
            var beers = await _unitOfWork.BeerRepository.GetAllAsync();
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };
            _cache.Set(cacheKey, beers, cacheOptions);
            stopwatch.Stop();
            Console.WriteLine($"Tiempo de respuesta (desde caché): {stopwatch.ElapsedMilliseconds} ms");
            return beers;
        }
    }
}
