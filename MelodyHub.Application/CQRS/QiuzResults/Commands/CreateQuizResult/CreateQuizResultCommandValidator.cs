using FluentValidation;

namespace MelodyHub.Application.CQRS.QiuzResults.Commands.CreateQuizResult;

public class CreateQuizResultCommandValidator
    : AbstractValidator<CreateQuizResultCommand>
{
    public CreateQuizResultCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required");

        RuleFor(x => x.QuizId)
            .NotEmpty().WithMessage("Quiz ID is required");

        RuleFor(x => x.Score)
            .GreaterThanOrEqualTo(0).WithMessage("Score cannot be negative")
            .LessThanOrEqualTo(x => x.MaxScore).WithMessage("Score cannot exceed MaxScore");

        RuleFor(x => x.MaxScore)
            .GreaterThan(0).WithMessage("MaxScore must be positive");
    }
}