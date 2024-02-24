using FluentValidation;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidator : AbstractValidator<UpdateStreamerCommand>
    {
        public UpdateStreamerCommandValidator()
        {
            RuleFor(streamer => streamer.Nombre)
                .NotNull().WithMessage("{Nombre} no permite valores nulos");

            RuleFor(streamer => streamer.Url)
               .NotNull().WithMessage("{Url} no permite valores nulos");
        }
    }
}
