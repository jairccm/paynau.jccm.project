using MediatR;

namespace paynau.jccm.project.Application.Features.People.Commands.UpdateCommand;

public class UpdatePersonCommand : IRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }
}
