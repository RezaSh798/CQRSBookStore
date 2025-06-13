using CQRSBookStore.Commands;
using CQRSBookStore.Data;
using CQRSBookStore.Models;
using MediatR;

namespace CQRSBookStore.Handlers.CommandHandlers;

public class RemoveBookCommandHandler(AppDbContext context) : IRequestHandler<RemoveBookCommand, int>
{
    private readonly AppDbContext _context = context;

    public async Task<int> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
    {
        Book? book = await _context.Books.FindAsync(request.Id);
        if (book == null)
            return 0;

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return request.Id; 
    }
}