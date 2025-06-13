using CQRSBookStore.Commands;
using CQRSBookStore.Data;
using CQRSBookStore.Models;
using CQRSBookStore.Queries;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace CQRSBookStore.Handlers.CommandHandlers;

public class RemoveBookCommandHandler
    (
        AppDbContext context,
        IValidator<RemoveBookCommand> validator,
        IMemoryCache cache
    )
    : IRequestHandler<RemoveBookCommand, int>
{
    private readonly AppDbContext _context = context;
    private readonly IValidator<RemoveBookCommand> _validator = validator;
    private readonly IMemoryCache _cache = cache;

    public async Task<int> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        Book? book = await _context.Books.FindAsync(request.Id);
        if (book == null)
            return 0;

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        _cache.Remove(GetBooksCachedQuery.CacheKey);
        return request.Id;
    }
}