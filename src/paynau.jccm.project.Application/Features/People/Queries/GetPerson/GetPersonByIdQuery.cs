using MediatR;
using paynau.jccm.project.Application.Features.People.Queries.ViewModels;

namespace paynau.jccm.project.Application.Features.People.Queries.GetPerson;

public class GetPersonByIdQuery : IRequest<PersonVm>
{
    public int _Id { get; set; }

    public GetPersonByIdQuery(int id)
    {
        _Id = id;
    }
}
