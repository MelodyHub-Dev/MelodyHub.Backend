using FluentValidation;

namespace MelodyHub.Application.CQRS.InstrumentCategories.Command.DeleteInstrumentCategory;

public class DeleteInstrumentCategoryCommandValidator
    : AbstractValidator<DeleteInstrumentCategoryCommand>
{
    public DeleteInstrumentCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Instrument Category Id must not be empty");
    }
}