using paynau.jccm.project.Domain.Common;

namespace paynau.jccm.project.Entities.Entities;

public partial class Person : BaseDomainModel
{

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }
}
