using FluentValidation;

namespace MelodyHub.Application.CQRS.InstrumentMaterials.Queries.GetInstrumentMaterialList;

public class GetInstrumentMaterialListQueryValidator
    : AbstractValidator<GetInstrumentMaterialListQuery>
{
    public GetInstrumentMaterialListQueryValidator()
    {
        
    }
}