using CQRSBookStore.Data;
using CQRSBookStore.Models;
using CQRSBookStore.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CQRSBookStore.Handlers.QueryHandlers;

public class GetBooksCachedQueryHandler
    (AppDbContext context, IMemoryCache cache)
    : IRequestHandler<GetBooksCachedQuery, List<Book>>
{
    private readonly AppDbContext _context = context;
    private readonly IMemoryCache _cache = cache;

    public async Task<List<Book>> Handle(GetBooksCachedQuery request, CancellationToken cancellationToken)
    {
        return await _cache.GetOrCreateAsync(GetBooksCachedQuery.CacheKey, async entry =>
        {
            entry.SlidingExpiration = request.SlidingExpiration;
            return await _context.Books.ToListAsync(cancellationToken);
        });
    }
}