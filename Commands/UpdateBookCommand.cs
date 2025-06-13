using MediatR;

namespace CQRSBookStore.Commands;

public class UpdateBookCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
}