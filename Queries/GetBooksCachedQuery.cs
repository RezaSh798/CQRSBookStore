using CQRSBookStore.Models;
using MediatR;

namespace CQRSBookStore.Queries;

public class GetBooksCachedQuery : IRequest<List<Book>>
{
    public static string CacheKey { get; } = "all_books";
    public TimeSpan? SlidingExpiration { get; } = TimeSpan.FromMinutes(10);
}