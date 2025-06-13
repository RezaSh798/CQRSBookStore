using CQRSBookStore.Commands;
using CQRSBookStore.Data;
using CQRSBookStore.Models;
using CQRSBookStore.Queries;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace CQRSBookStore.Handlers.CommandHandlers;

public class CreateBookCommandHandler
    (
        AppDbContext context,
        IValidator<CreateBookCommand> validator,
        IMemoryCache cache
    )
    : IRequestHandler<CreateBookCommand, int>
{
    private readonly AppDbContext _context = context;
    private readonly IValidator<CreateBookCommand> _validator = validator;
    private readonly IMemoryCache _cache = cache;

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        Book book = new()
        {
            Title = request.Title,
            Author = request.Author,
        };

        _context.Add(book);
        await _context.SaveChangesAsync();

        _cache.Remove(GetBooksCachedQuery.CacheKey);
        return book.Id;
    }
}