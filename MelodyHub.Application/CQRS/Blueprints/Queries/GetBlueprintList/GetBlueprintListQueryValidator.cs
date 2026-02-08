using FluentValidation;

namespace MelodyHub.Application.CQRS.Blueprints.Queries.GetBlueprintList;

public class GetBlueprintListQueryValidator
    : AbstractValidator<GetBlueprintListQuery>
{
    public GetBlueprintListQueryValidator()
    {
        
    }
}