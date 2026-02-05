using FluentValidation;

namespace MelodyHub.Application.CQRS.Quizzes.Queries.GetQuizDetails;

public class GetQuizDetailsValidator
    : AbstractValidator<GetQuizDetailsQuery>
{
    public GetQuizDetailsValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Quiz Id must not be empty");
    }
}