using MediatR;
using paynau.jccm.project.Application.Features.People.Queries.ViewModels;

namespace paynau.jccm.project.Application.Features.People.Queries.GetPeopleList;

public class GetPeopleListQuery : IRequest<List<PersonVm>>
{
}
