namespace paynau.jccm.project.Application.Features.People.Queries.ViewModels;

public class PersonVm
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public String CreatedDate { get; set; } = string.Empty;
}
