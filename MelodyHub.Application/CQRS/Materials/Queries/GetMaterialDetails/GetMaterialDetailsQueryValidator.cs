using FluentValidation;

namespace MelodyHub.Application.CQRS.Materials.Queries.GetMaterialDetails;

public class GetMaterialDetailsQueryValidator
    : AbstractValidator<GetMaterialDetailsQuery>
{
    public GetMaterialDetailsQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Material Id must not be empty");
    }
}