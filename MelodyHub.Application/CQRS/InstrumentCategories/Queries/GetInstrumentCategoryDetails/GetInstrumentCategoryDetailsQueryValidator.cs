using FluentValidation;

namespace MelodyHub.Application.CQRS.InstrumentCategories.Queries.GetInstrumentCategoryDetails;

public class GetInstrumentCategoryDetailsQueryValidator
    : AbstractValidator<GetInstrumentCategoryDetailsQuery>
{
    public GetInstrumentCategoryDetailsQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("User Id must not be empty");
    }
}