using MediatR;
using Microsoft.Extensions.Logging;
using paynau.jccm.project.Application.Contracts.Persistence;
using paynau.jccm.project.Entities.Entities;

namespace paynau.jccm.project.Application.Features.People.Commands.CreateCommand;

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CreatePersonCommandHandler> _logger;

    public CreatePersonCommandHandler(IUnitOfWork unitOfWork, ILogger<CreatePersonCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var personEntity = new Person
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            PhoneNumber = request.PhoneNumber,
            CreatedDate = DateTime.Now
        };

        _unitOfWork.PersonRepository.AddEntity(personEntity);

        var result = await _unitOfWork.Complete();

        if (result <= 0)
        {
            throw new Exception($"No se pudo insertar el record de persona");
        }

        _logger.LogInformation($"Persona {personEntity.Id} fue creado existosamente");

        return personEntity.Id;
    }
}
