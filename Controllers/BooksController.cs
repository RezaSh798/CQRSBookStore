using CQRSBookStore.Commands;
using CQRSBookStore.Models;
using CQRSBookStore.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSBookStore.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
public class BooksController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<Book>>> FindMany()
    {
        return await _mediator.Send(new GetBooksQuery());
    }

    [HttpPost]
    public async Task<int> Create(CreateBookCommand command)
    {
        return await _mediator.Send(command);
    }
}