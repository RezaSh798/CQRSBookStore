using CQRSBookStore.Models;
using MediatR;

namespace CQRSBookStore.Queries;

public class GetBooksQuery : IRequest<List<Book>> { }