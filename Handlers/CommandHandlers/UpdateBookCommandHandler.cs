using CQRSBookStore.Commands;
using CQRSBookStore.Data;
using CQRSBookStore.Models;
using CQRSBookStore.Queries;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace CQRSBookStore.Handlers.CommandHandlers;

public class UpdateBookCommandHandler
    (
        AppDbContext context,
        IValidator<UpdateBookCommand> validator,
        IMemoryCache cache
    )
    : IRequestHandler<UpdateBookCommand, int>
{
    private readonly AppDbContext _context = context;
    private readonly IValidator<UpdateBookCommand> _validator = validator;
    private readonly IMemoryCache _cache = cache;

    public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        Book? book = await _context.Books.FindAsync(request.Id);
        if (book == null)
            return 0;

        _context.Entry(book).CurrentValues.SetValues(request);
        await _context.SaveChangesAsync();

        _cache.Remove(GetBooksCachedQuery.CacheKey);
        return book.Id;
    }
}