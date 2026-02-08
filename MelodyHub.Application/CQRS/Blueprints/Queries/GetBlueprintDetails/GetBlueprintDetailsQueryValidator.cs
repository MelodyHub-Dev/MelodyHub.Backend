using FluentValidation;

namespace MelodyHub.Application.CQRS.Blueprints.Queries.GetBlueprintDetails;

public class GetBlueprintDetailsQueryValidator
    : AbstractValidator<GetBlueprintDetailsQuery>
{
    public GetBlueprintDetailsQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Blueprint Id must not be empty");
    }
}
