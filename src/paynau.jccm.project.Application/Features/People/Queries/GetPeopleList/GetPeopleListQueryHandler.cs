using MediatR;
using paynau.jccm.project.Application.Contracts.Persistence;
using paynau.jccm.project.Application.Features.People.Queries.ViewModels;

namespace paynau.jccm.project.Application.Features.People.Queries.GetPeopleList;

public class GetPeopleListQueryHandler : IRequestHandler<GetPeopleListQuery, List<PersonVm>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPeopleListQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PersonVm>> Handle(GetPeopleListQuery request, CancellationToken cancellationToken)
    {
        var peoples = await _unitOfWork.PersonRepository.GetAllAsync();

        return peoples.Select( person =>  new PersonVm
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            DateOfBirth = person.DateOfBirth,
            Email = person.Email,
            PhoneNumber = person.PhoneNumber,
            CreatedDate = person.CreatedDate.ToString("dd/MM/yyyy hh:mm:ss")
        }).ToList();
    }
}
