using FluentValidation;

namespace MelodyHub.Application.CQRS.QiuzResults.Commands.DeleteQuizResult;

public class DeleteQuizResultCommandValidator 
    : AbstractValidator<DeleteQuizResultCommand>
{
    public DeleteQuizResultCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Quiz result ID is required");
    }
}
