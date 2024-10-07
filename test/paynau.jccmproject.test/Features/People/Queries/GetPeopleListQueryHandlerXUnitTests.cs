using Moq;
using paynau.jccm.project.Application.Features.People.Queries.GetPeopleList;
using paynau.jccm.project.Application.Features.People.Queries.ViewModels;
using paynau.jccm.project.Infraestructure.Repositories;
using paynau.jccmproject.test.Mocks;
using Shouldly;
using Xunit;
namespace paynau.jccmproject.test.Features.People.Queries;

public class GetPeopleListQueryHandlerXUnitTests
{
    private readonly Mock<UnitOfWork> _unitOfWork;

    public GetPeopleListQueryHandlerXUnitTests()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();

        MockPersonRepository.AddDataPersonRepository(_unitOfWork.Object.PaynauDbContext);

    }

    [Fact]
    public async Task GetPeopleListTest()
    {
        var handler = new GetPeopleListQueryHandler(_unitOfWork.Object);
        var request = new GetPeopleListQuery();

        var result = await handler.Handle(request, CancellationToken.None);

        result.ShouldBeOfType<List<PersonVm>>();

        result.Count.ShouldBe(4);
    }

}
