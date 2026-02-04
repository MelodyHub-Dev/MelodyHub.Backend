using FluentValidation;

namespace MelodyHub.Application.CQRS.Instruments.Commands.DeleteInstrument;

public class DeleteInstrumentCommandValidator
    : AbstractValidator<DeleteInstrumentCommand>
{
    public DeleteInstrumentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Instrument Id must not be empty");
    }
}