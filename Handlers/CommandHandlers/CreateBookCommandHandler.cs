using CQRSBookStore.Commands;
using CQRSBookStore.Data;
using CQRSBookStore.Models;
using FluentValidation;
using MediatR;

namespace CQRSBookStore.Handlers.CommandHandlers;

public class CreateBookCommandHandler
    (AppDbContext context, IValidator<CreateBookCommand> validator)
    : IRequestHandler<CreateBookCommand, int>
{
    private readonly AppDbContext _context = context;
    private readonly IValidator<CreateBookCommand> _validator = validator;

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

        return book.Id;
    }
}