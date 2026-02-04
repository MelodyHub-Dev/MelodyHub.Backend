using FluentValidation;

namespace MelodyHub.Application.CQRS.Instruments.Queries.GetInstrumentDetails;

public class GetInstrumentDetailsQueryValidator 
    : AbstractValidator<GetInstrumentDetailsQuery>
{
    public GetInstrumentDetailsQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Instrument ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid instrument ID");
    }
}