using Microsoft.Extensions.Logging;
using Moq;
using paynau.jccm.project.Application.Features.People.Commands.CreateCommand;
using paynau.jccm.project.Infraestructure.Repositories;
using paynau.jccmproject.test.Mocks;
using Shouldly;
using Xunit;

namespace paynau.jccmproject.test.Features.People.Commands;

public class CreatePersonCommandHandlerXUnitTests
{
    private readonly Mock<UnitOfWork> _unitOfWork;
    private readonly Mock<ILogger<CreatePersonCommandHandler>> _logger;

    public CreatePersonCommandHandlerXUnitTests()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();

        _logger = new Mock<ILogger<CreatePersonCommandHandler>>();

        MockPersonRepository.AddDataPersonRepository(_unitOfWork.Object.PaynauDbContext);
    }

    [Fact]
    public async Task CreateStreamerCommand_InputStreamer_ReturnsNumber()
    {
        var streamerInput = new CreatePersonCommand
        {
            FirstName = "data",
            LastName = "second data"
        };

        var handler = new CreatePersonCommandHandler(_unitOfWork.Object, _logger.Object);

        var result = await handler.Handle(streamerInput, CancellationToken.None);

        result.ShouldBeOfType<int>();
    }


}