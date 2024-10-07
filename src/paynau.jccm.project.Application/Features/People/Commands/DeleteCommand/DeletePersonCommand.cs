using MediatR;

namespace paynau.jccm.project.Application.Features.People.Commands.DeleteCommand;

public class DeletePersonCommand : IRequest
{
    public int Id { get; set; }
}
