using CQRSBookStore.Commands;
using CQRSBookStore.Data;
using CQRSBookStore.Models;
using MediatR;

namespace CQRSBookStore.Handlers.CommandHandlers;

public class CreateBookCommandHandler(AppDbContext context) : IRequestHandler<CreateBookCommand, int>
{
    readonly AppDbContext _context = context;

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        Book book = new()
        {
            Title = request.Title,
            Author = request.Author,
        };

        _context.Add(book);
        await _context.SaveChangesAsync();

        return book.Id;
    }
}