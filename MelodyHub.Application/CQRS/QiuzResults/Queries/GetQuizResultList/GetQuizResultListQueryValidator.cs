using FluentValidation;

namespace MelodyHub.Application.CQRS.QiuzResults.Queries.GetQuizResultList;

public class GetQuizResultListQueryValidator
    : AbstractValidator<GetQuizResultListQuery>
{
    public GetQuizResultListQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Quiz result ID is required");
    }
}
