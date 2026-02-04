using FluentValidation;

namespace MelodyHub.Application.CQRS.Materials.Commands.DeleteMaterial;

public class DeleteMaterialCommandValidator
    : AbstractValidator<DeleteMaterialCommand>
{
    public DeleteMaterialCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Material Id must not be empty");
    }
}