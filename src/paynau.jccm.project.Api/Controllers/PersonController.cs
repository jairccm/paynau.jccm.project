using MediatR;
using Microsoft.AspNetCore.Mvc;
using paynau.jccm.project.Application.Features.People.Commands.CreateCommand;
using paynau.jccm.project.Application.Features.People.Commands.DeleteCommand;
using paynau.jccm.project.Application.Features.People.Commands.UpdateCommand;
using paynau.jccm.project.Application.Features.People.Queries.GetPeopleList;
using paynau.jccm.project.Application.Features.People.Queries.GetPerson;
using paynau.jccm.project.Application.Features.People.Queries.ViewModels;
using System.Net;

namespace paynau.jccm.project.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private IMediator _mediator;

    public PersonController(ILogger<PersonController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost(Name = "CreatePerson")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreatePerson([FromBody] CreatePersonCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut(Name = "UpdatePerson")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }


    [HttpDelete("{id}", Name = "DeletePerson")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeletePerson(int id)
    {
        var command = new DeletePersonCommand
        {
            Id = id
        };

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpGet("{id}", Name = "GetPerson")]
    [ProducesResponseType(typeof(IEnumerable<PersonVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<PersonVm>>> GetPersonById(int id)
    {
        var query = new GetPersonByIdQuery(id);
        var Person = await _mediator.Send(query);
        return Ok(Person);
    }

    [HttpGet(Name = "GetAllPerson")]
    [ProducesResponseType(typeof(IEnumerable<PersonVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<PersonVm>>> GetAllPerson()
    {
        var query = new GetPeopleListQuery();
        var peoples = await _mediator.Send(query);
        return Ok(peoples);
    }
}
