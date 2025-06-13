using MediatR;

namespace CQRSBookStore.Commands;

public class CreateBookCommand : IRequest<int>
{
    public required string Title { get; set; }
    public required string Author { get; set; }
}