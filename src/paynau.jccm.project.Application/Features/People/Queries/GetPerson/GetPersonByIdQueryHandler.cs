using MediatR;
using paynau.jccm.project.Application.Contracts.Persistence;
using paynau.jccm.project.Application.Features.People.Queries.ViewModels;

namespace paynau.jccm.project.Application.Features.People.Queries.GetPerson;

public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonVm>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPersonByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PersonVm> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var person = await _unitOfWork.PersonRepository.GetByIdAsync(request._Id);

        return new PersonVm { 
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            DateOfBirth = person.DateOfBirth,
            Email  = person.Email,
            PhoneNumber = person.PhoneNumber,
            CreatedDate = person.CreatedDate.ToString("dd/MM/yyyy hh:mm:ss")
        };
    }
}
