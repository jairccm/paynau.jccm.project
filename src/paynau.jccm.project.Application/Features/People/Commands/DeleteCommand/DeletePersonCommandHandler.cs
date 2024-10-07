using MediatR;
using Microsoft.Extensions.Logging;
using paynau.jccm.project.Application.Contracts.Persistence;
using paynau.jccm.project.Application.Exceptions;
using paynau.jccm.project.Entities.Entities;

namespace paynau.jccm.project.Application.Features.People.Commands.DeleteCommand;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DeletePersonCommandHandler> _logger;

    public DeletePersonCommandHandler(IUnitOfWork unitOfWork, ILogger<DeletePersonCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var personToDelete = await _unitOfWork.PersonRepository.GetByIdAsync(request.Id);
        if (personToDelete == null)
        {
            _logger.LogError($"{request.Id} persona no existe en el sistema");
            throw new NotFoundException(nameof(Person), request.Id);
        }

        _unitOfWork.PersonRepository.DeleteEntity(personToDelete);

        await _unitOfWork.Complete();

        _logger.LogInformation($"El {request.Id} persona fue eliminado con exito");
    }
}
