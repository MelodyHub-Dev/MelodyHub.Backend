using FluentValidation;

namespace MelodyHub.Application.CQRS.Materials.Queries.GetMaterialList;

public class GetMaterialListQueryValidator
    : AbstractValidator<GetMaterialListQuery>
{
    public GetMaterialListQueryValidator()
    {
        
    }
}