using FluentValidation;

namespace MelodyHub.Application.CQRS.InstrumentCategories.Queries.GetInstrumentCategoryList;

public class GetInstrumentCategoryListQueryValidator
    : AbstractValidator<GetInstrumentCategoryListQuery>
{
    public GetInstrumentCategoryListQueryValidator()
    {
        
    }
}