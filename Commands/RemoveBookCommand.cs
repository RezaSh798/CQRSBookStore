using MediatR;

namespace CQRSBookStore.Commands;

public class RemoveBookCommand : IRequest<int>
{
    public int Id { get; set; }
}