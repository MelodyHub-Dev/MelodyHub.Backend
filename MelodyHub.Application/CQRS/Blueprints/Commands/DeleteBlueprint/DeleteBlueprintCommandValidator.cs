using FluentValidation;

namespace MelodyHub.Application.CQRS.Blueprints.Commands.DeleteBlueprint;

public class DeleteBlueprintCommandValidator
    : AbstractValidator<DeleteBlueprintCommand>
{
    public DeleteBlueprintCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Blueprint Id must not be empty");
    }
}
