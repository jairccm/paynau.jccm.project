using MediatR;

namespace paynau.jccm.project.Application.Features.People.Commands.CreateCommand;

public class CreatePersonCommand : IRequest<int>
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }
}
