using FluentValidation;
using System.Globalization;

namespace MelodyHub.Application.CQRS.InstrumentMaterials.Commands.UpdateInstrumentMaterial;

public class UpdateInstrumentMaterialCommandValidator 
    : AbstractValidator<UpdateInstrumentMaterialCommand>
{
    public UpdateInstrumentMaterialCommandValidator()
    {
        RuleFor(x => x.InstrumentId)
           .Cascade(CascadeMode.Stop)
           .NotEmpty().WithMessage("Instrument ID is required")
           .NotEqual(Guid.Empty).WithMessage("Invalid instrument ID");

        RuleFor(x => x.MaterialId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Material ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid material ID")
            .NotEqual(x => x.InstrumentId).WithMessage("Instrument ID and Material ID cannot be the same");

        RuleFor(x => x.Quantity)
            .Cascade(CascadeMode.Stop)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0")
            .LessThanOrEqualTo(1000).WithMessage("Quantity must not exceed 1000")
            .Must(quantity => decimal.Round(quantity, 2) == quantity)
            .WithMessage("Quantity must have at most 2 decimal places")
            .Must(quantity => !quantity.ToString(CultureInfo.InvariantCulture).Contains('E'))
            .WithMessage("Quantity must not be in scientific notation");

        RuleFor(x => x.Notes)
            .MaximumLength(500).WithMessage("Notes must not exceed 500 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.Notes))
            .Must(notes => notes == null || !notes.StartsWith(" ") && !notes.EndsWith(" "))
            .WithMessage("Notes cannot start or end with whitespace")
            .When(x => !string.IsNullOrWhiteSpace(x.Notes));
    }
}