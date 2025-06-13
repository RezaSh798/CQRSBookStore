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
        return await _mediator.Send(new GetBooksCachedQuery());
    }

    [HttpPost]
    public async Task<int> Create(CreateBookCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<int> Update(int  id, UpdateBookCommand command)
    {
        command.Id = id;
        return await _mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<int> Remove(int id)
    {
        return await _mediator.Send(new RemoveBookCommand { Id = id });
    }
}