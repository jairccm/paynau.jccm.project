using FluentValidation;

namespace paynau.jccm.project.Application.Features.People.Commands.UpdateCommand;

public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
{
    public UpdatePersonCommandValidator()
    {
        RuleFor(p => p.FirstName)
        .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
        .NotNull()
        .MaximumLength(70).WithMessage("{Nombre} no puede exceder los 70 caracteres");

        RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{Apellidos} no puede estar en blanco")
                .NotNull()
                .MaximumLength(100).WithMessage("{Apellidos} no puede exceder los 100 caracteres");

        RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("{nro de celular} no puede estar en blanco")
                .NotNull()
                .MaximumLength(20).WithMessage("{nro de celular} no puede exceder los 20 caracteres");

        RuleFor(p => p.Email)
               .NotEmpty().WithMessage("{Email} no puede estar en blanco")
               .NotNull()
               .MaximumLength(100).WithMessage("{Email} no puede exceder los 100 caracteres");

        RuleFor(p => p.DateOfBirth)
       .NotNull().WithMessage("{fecha de nacimiento} no puede estar en blanco");
    }
}
