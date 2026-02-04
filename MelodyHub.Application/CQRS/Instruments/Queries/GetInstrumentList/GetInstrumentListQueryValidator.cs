using FluentValidation;

namespace MelodyHub.Application.CQRS.Instruments.Queries.GetInstrumentList;

public class GetInstrumentListQueryValidator
    : AbstractValidator<GetInstrumentListQuery>
{
    public GetInstrumentListQueryValidator()
    {
        
    }
}