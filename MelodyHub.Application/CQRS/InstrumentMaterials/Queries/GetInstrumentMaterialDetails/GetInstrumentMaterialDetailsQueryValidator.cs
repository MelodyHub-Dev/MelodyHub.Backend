using FluentValidation;

namespace MelodyHub.Application.CQRS.InstrumentMaterials.Queries.GetInstrumentMaterialDetails;

public class GetInstrumentMaterialDetailsQueryValidator
    : AbstractValidator<GetInstrumentMaterialDetailsQuery>
{
    public GetInstrumentMaterialDetailsQueryValidator()
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
    }
}