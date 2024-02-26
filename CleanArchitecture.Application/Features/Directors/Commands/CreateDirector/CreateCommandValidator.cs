using FluentValidation;

namespace CleanArchitecture.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(director => director.Nombre)
                .NotNull().WithMessage("{Nombre} no puede ser nulo");

            RuleFor(director => director.Apellido)
            .NotNull().WithMessage("{Apellido} no puede ser nulo");
        }
    }
}
