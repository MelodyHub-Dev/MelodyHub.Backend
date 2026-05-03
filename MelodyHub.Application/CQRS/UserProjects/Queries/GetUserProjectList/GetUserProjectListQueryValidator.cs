using FluentValidation;

namespace MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectList;

public class GetUserProjectListQueryValidator
    : AbstractValidator<GetUserProjectListQuery>
{
    public GetUserProjectListQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotEqual(Guid.Empty)
            .When(x => x.UserId.HasValue);

        RuleFor(x => x.InstrumentId)
            .NotEmpty()
            .NotEqual(Guid.Empty)
            .When(x => x.InstrumentId.HasValue);
    }
}