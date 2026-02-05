using FluentValidation;

namespace MelodyHub.Application.CQRS.Quizzes.Commands.DeleteQuiz;

public class DeleteQuizCommandValidator 
    : AbstractValidator<DeleteQuizCommand>
{
    public DeleteQuizCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Quiz Id must not be empty");
    }
}
