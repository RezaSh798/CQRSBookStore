using CQRSBookStore.Data;
using CQRSBookStore.Models;
using CQRSBookStore.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSBookStore.Handlers.QueryHandlers;

public class GetBooksQueryHandler(AppDbContext context) : IRequestHandler<GetBooksQuery, List<Book>>
{
    readonly AppDbContext _context = context;

    public async Task<List<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        return await _context.Books.ToListAsync();
    }
}