using Microsoft.Extensions.Logging;
using Moq;
using paynau.jccm.project.Application.Exceptions;
using paynau.jccm.project.Application.Features.People.Commands.CreateCommand;
using paynau.jccm.project.Application.Features.People.Commands.UpdateCommand;
using paynau.jccm.project.Entities.Entities;
using paynau.jccm.project.Infraestructure.Repositories;
using paynau.jccmproject.test.Mocks;
using Xunit;

namespace paynau.jccmproject.test.Features.People.Commands;

public class UpdatePersonCommandHandlerXUnitTests
{
    private readonly Mock<UnitOfWork> _unitOfWork;
    private readonly Mock<ILogger<UpdatePersonCommandHandler>> _logger;

    public UpdatePersonCommandHandlerXUnitTests()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();

        _logger = new Mock<ILogger<UpdatePersonCommandHandler>>();

        MockPersonRepository.AddDataPersonRepository(_unitOfWork.Object.PaynauDbContext);
    }

    [Fact]
    public async Task Handle_ShouldThrowNotFoundException_WhenPersonDoesNotExist()
    {
        var command = new UpdatePersonCommand
        {
            Id = 99,
            FirstName = "Non-existent",
            LastName = "Person"
        };

        var handler = new UpdatePersonCommandHandler(_unitOfWork.Object, _logger.Object);

        await Xunit.Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(command, CancellationToken.None));
        
    }
}
