using FluentValidation;

namespace MelodyHub.Application.CQRS.QuizQuestions.Commands.DeleteQuizQuestion;

public class DeleteQuizQuestionCommandValidator
    : AbstractValidator<DeleteQuizQuestionCommand>
{
    public DeleteQuizQuestionCommandValidator()
    {
        RuleFor(x => x.QuizQuestionId)
            .NotEqual(Guid.Empty)
            .WithMessage("Quiz question Id must not be empty");
    }
}
