using MediatR;
using Microsoft.Extensions.Logging;
using paynau.jccm.project.Application.Contracts.Persistence;
using paynau.jccm.project.Application.Exceptions;
using paynau.jccm.project.Entities.Entities;

namespace paynau.jccm.project.Application.Features.People.Commands.UpdateCommand;

public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UpdatePersonCommandHandler> _logger;

    public UpdatePersonCommandHandler(IUnitOfWork unitOfWork, ILogger<UpdatePersonCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var personToUpdate = await _unitOfWork.PersonRepository.GetByIdAsync(request.Id);

        if (personToUpdate == null)
        {
            _logger.LogError($"No se encontro el Person id {request.Id}");
            throw new NotFoundException(nameof(Person), request.Id);
        }

        personToUpdate.FirstName = request.FirstName;
        personToUpdate.LastName = request.LastName;
        personToUpdate.Email = request.Email;
        personToUpdate.DateOfBirth = request.DateOfBirth;
        personToUpdate.PhoneNumber = request.PhoneNumber;


        _unitOfWork.PersonRepository.UpdateEntity(personToUpdate);

        await _unitOfWork.Complete();

        _logger.LogInformation($"La operacion fue exitosa actualizando el streamer {request.Id}");
    }
}
