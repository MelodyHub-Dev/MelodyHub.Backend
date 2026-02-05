using FluentValidation;

namespace MelodyHub.Application.CQRS.QuizQuestions.Queries.GetQuizQuestionList;

public class GetQuizQuestionQueryValidator
    : AbstractValidator<GetQuizQuestionListQuery>
{
    public GetQuizQuestionQueryValidator()
    {
        RuleFor(x => x.QuizId)
            .NotEqual(Guid.Empty)
            .WithMessage("Quiz Id must not be empty");
    }
}
